namespace Itmo.ObjectOrientedProgramming.Lab1;

public abstract class Contract
{
    public abstract record ContractResults;

    public record ContractSuccess
    (
        int WorkTime,
        int HarvestCyclesAmount,
        decimal TotalHarvestedVolume,
        IReadOnlyDictionary<Type, int> StoragedMinerals,
        decimal TotalRevenue,
        decimal TotalRent,
        decimal TaxesAmount,
        decimal NetProfit) : ContractResults;

    public record ContractFailure
    (string ErrorMessage) : ContractResults;

    public AsteroidBelt TargetAsteroidBelt { get; init; }

    public Fleet ContractFleet { get; init; }

    public MineralPriceData PriceList { get; init; }

    public Station ContractStation { get; }

    public ValidationInfo ValidationStatus { get; init; }

    public int TimeToField { get; init; }

    protected Contract(AsteroidBelt selectedBelt, Fleet selectedFleet, MineralPriceData givenPriceData, Station contractStation)
    {
        PriceList = givenPriceData;
        TargetAsteroidBelt = selectedBelt;
        ContractFleet = selectedFleet;
        ContractStation = contractStation;
        ValidationStatus = ValidateContract();

        TimeToField = selectedBelt.Distance / selectedFleet.Speed;
        TotalWorkTime = 0;
    }

    public ContractResults ExecuteContract()
    {
        if (!ValidationStatus.Success)
        {
            return new ContractFailure(
                ErrorMessage: ValidationStatus?.ErrorMessage ?? "Unknown error");
        }

        int totalHarvestedOre = 0;
        int curVoyage = 0;

        decimal totalRevenue = 0;
        decimal taxes = 0;
        decimal netProfit = 0;

        while (CanStartVoyage())
        {
            UpdateStateBeforeHarvest();
            int curVoyageHarvest = StartHarvestCycle();
            UpdateStateAfterHarvest(curVoyageHarvest);

            ContractStation.ProcessOres(new PairDataPack<Ore, decimal>(TargetAsteroidBelt.BeltOre, curVoyageHarvest));
            Station.SaleReport mineralSaleReport = ContractStation.SellMinerals(PriceList);

            totalRevenue += mineralSaleReport.TotalRevenue;
            taxes += mineralSaleReport.Taxes;
            netProfit += mineralSaleReport.NetProfit;

            ContractFleet.Strategy.ClearStorages(ContractFleet.Ships);

            curVoyage++;
        }

        return new ContractSuccess(
            WorkTime: TotalWorkTime,
            HarvestCyclesAmount: curVoyage,
            TotalHarvestedVolume: totalHarvestedOre,
            StoragedMinerals: new Dictionary<Type, int>(),
            TotalRevenue: totalRevenue,
            TotalRent: TotalWorkTime * ContractFleet.UpkeerPerTimeUnit,
            TaxesAmount: taxes,
            NetProfit: netProfit);
    }

    public record ValidationInfo(
        bool Success,
        string? ErrorMessage);

    protected abstract bool CanStartVoyage();

    protected int StartHarvestCycle()
    {
        int totalMinedOre = 0;
        int curHarvestCycle = 0;

        while (true)
        {
            int cycleMined = 0;
            foreach (Ship ship in ContractFleet.Ships)
            {
                int curMined = ship.SimulateHarvestCycle(curHarvestCycle);
                if (!ContractFleet.Strategy.TryStoringOre(curMined, ship, ContractFleet.Ships)) continue;
                cycleMined += curMined;
            }

            if (cycleMined == 0) break;
            totalMinedOre += cycleMined;
            curHarvestCycle++;
        }

        return totalMinedOre;
    }

    protected abstract void UpdateStateBeforeHarvest();

    protected abstract void UpdateStateAfterHarvest(int cycleHarvest);

    protected int TotalWorkTime { get; set; }

    private ValidationInfo ValidateContract()
    {
        if (!ContractFleet.CanMineFirstCycle())
        {
            return new ValidationInfo(
                Success: false,
                ErrorMessage: "Fleet can't mine first cycle");
        }

        foreach (KeyValuePair<Type, decimal> mineralOutput in TargetAsteroidBelt.BeltOre.RefineOutputList)
        {
            if (!PriceList.PriceList.ContainsKey(mineralOutput.Key))
            {
                return new ValidationInfo(
                    Success: false,
                    ErrorMessage: mineralOutput.Key.ToString() + " absent in price list");
            }
        }

        return new ValidationInfo(
                Success: true,
                ErrorMessage: null);
    }
}