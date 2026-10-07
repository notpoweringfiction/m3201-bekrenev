using Itmo.ObjectOrientedProgramming.Lab1.Utils;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public abstract class Contract
{
    public abstract record ContractResults;

    public record ContractSuccess
    (
        int WorkTime,
        int HarvestCyclesAmount,
        decimal TotalHarvestedVolume,
        IReadOnlyDictionary<TypedValue<Ore>, int> StoragedOre,
        IReadOnlyDictionary<TypedValue<Mineral>, int> SoldMinerals,
        decimal TotalRevenue,
        decimal TotalRent,
        decimal TaxesAmount,
        decimal NetProfit) : ContractResults;

    public record ContractFailure
    (ContractError Error) : ContractResults;

    public AsteroidBelt TargetAsteroidBelt { get; init; }

    public Fleet ContractFleet { get; init; }

    public MineralPriceData PriceList { get; init; }

    public Station ContractStation { get; init; }

    public record ValidationInfo()
    {
        public record ContractValid() : ValidationInfo;

        public record ContractInvalid(ContractError Error) : ValidationInfo;
    }

    public ValidationInfo ValidationStatus { get; init; }

    public int TimeToField { get; init; }

    protected Contract(AsteroidBelt selectedBelt, Fleet selectedFleet, MineralPriceData givenPriceData, Station contractStation)
    {
        PriceList = givenPriceData;
        TargetAsteroidBelt = selectedBelt;
        ContractFleet = selectedFleet;
        ContractStation = contractStation;
        ValidationStatus = ValidateContract();

        TimeToField = selectedBelt.Distance.Value / selectedFleet.Speed.Value;
        TotalWorkTime = 0;
    }

    public ContractResults ExecuteContract()
    {
        switch (ValidationStatus)
        {
            case ValidationInfo.ContractValid valid:
                break;
            case ValidationInfo.ContractInvalid invalid:
                return new ContractFailure(
                    Error: invalid.Error);
            default:
                return new ContractFailure(
                    Error: new UnknownError("Unknown error"));
        }

        int totalHarvestedOre = 0;
        int curVoyage = 0;

        decimal totalRevenue = 0;
        decimal taxes = 0;
        decimal netProfit = 0;

        Dictionary<TypedValue<Mineral>, int> soldMinerals = new();

        while (CanStartVoyage())
        {
            UpdateStateBeforeVoyage();
            int curVoyageHarvest = CanStartHarvestCycle() ? StartHarvestCycle() : 0;
            totalHarvestedOre += curVoyageHarvest;
            UpdateStateAfterVoyage(curVoyageHarvest);

            ContractStation.ProcessOres(new TypedValue<Ore>(TargetAsteroidBelt.BeltOre), new NonNegativeInt(curVoyageHarvest));
            Station.SaleReport mineralSaleReport = ContractStation.SellMinerals(PriceList);

            totalRevenue += mineralSaleReport.TotalRevenue;
            taxes += mineralSaleReport.Taxes;
            netProfit += mineralSaleReport.NetProfit;

            foreach (KeyValuePair<TypedValue<Mineral>, int> pair in mineralSaleReport.SoldMinerals)
            {
                soldMinerals.TryAdd(pair.Key, 0);
                soldMinerals[pair.Key] += pair.Value;
            }

            ContractFleet.Strategy.ClearStorages(ContractFleet.Ships);

            curVoyage++;
        }

        Dictionary<TypedValue<Ore>, int> storagedOre = new();

        foreach (KeyValuePair<TypedValue<Ore>, int> pair in ContractStation.OreStorage)
        {
            storagedOre.TryAdd(pair.Key, pair.Value);
        }

        return new ContractSuccess(
            WorkTime: TotalWorkTime,
            HarvestCyclesAmount: curVoyage,
            TotalHarvestedVolume: totalHarvestedOre,
            StoragedOre: storagedOre,
            SoldMinerals: soldMinerals,
            TotalRevenue: totalRevenue,
            TotalRent: TotalWorkTime * ContractFleet.UpkeerPerTimeUnit.Value,
            TaxesAmount: taxes,
            NetProfit: netProfit - (TotalWorkTime * ContractFleet.UpkeerPerTimeUnit.Value));
    }

    protected abstract bool CanStartVoyage();

    protected abstract bool CanStartHarvestCycle();

    protected int StartHarvestCycle()
    {
        int totalMinedOre = 0;
        int curHarvestCycle = 0;

        while (CanStartHarvestCycle())
        {
            int cycleMined = 0;
            foreach (Ship ship in ContractFleet.Ships)
            {
                int curMined = ship.Model.SimulateHarvestCycle(curHarvestCycle);
                if (!ContractFleet.Strategy.TryStoringOre(curMined, ship, ContractFleet.Ships)) continue;
                cycleMined += curMined;
            }

            if (cycleMined == 0) break;
            UpdateStateAfterHarvestCycle(cycleMined);
            totalMinedOre += cycleMined;
            curHarvestCycle++;
        }

        TotalWorkTime += --curHarvestCycle;

        return totalMinedOre;
    }

    protected abstract void UpdateStateBeforeVoyage();

    protected abstract void UpdateStateAfterHarvestCycle(int cycleHarvest);

    protected abstract void UpdateStateAfterVoyage(int voyageHarvest);

    protected int TotalWorkTime { get; set; }

    private ValidationInfo ValidateContract()
    {
        if (!ContractFleet.CanMineFirstCycle())
        {
            return new ValidationInfo.ContractInvalid(
                Error: new FleetError("Fleet can't mine first cycle"));
        }

        foreach (KeyValuePair<TypedValue<Mineral>, int> mineralOutput in TargetAsteroidBelt.BeltOre.RefineOutputList)
        {
            if (!PriceList.Value.ContainsKey(mineralOutput.Key.ValueType))
            {
                return new ValidationInfo.ContractInvalid(
                    Error: new PriceListError(mineralOutput.Key.ToString() + " absent in price list"));
            }
        }

        return new ValidationInfo.ContractValid();
    }
}