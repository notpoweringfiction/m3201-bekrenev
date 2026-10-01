namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Contracts;

public class TimeContract : Contract
{
    public int ContractTime { get; init; }

    private int TimeToField { get; init; }

    private int HarvestCycle(int cycleIndex)
    {
        int totalMinedOre = 0;
        foreach (Ship ship in ContractFleet.Ships)
        {
            int curMined = ship.SimulateHarvestCycle(cycleIndex);
            if (!ContractFleet.Strategy.TryStoringOre(curMined, ship, ContractFleet.Ships)) continue;
            totalMinedOre += curMined;
        }

        return totalMinedOre;
    }

    public TimeContract(AsteroidBelt selectedBelt, Fleet selectedFleet, MineralPriceData givenPriceList, Station contractStation, int contractTime)
        : base(selectedBelt, selectedFleet, givenPriceList, contractStation)
    {
        TimeToField = selectedBelt.Distance / selectedFleet.Speed;
        ContractTime = contractTime;

        ValidationInfo valid = ValidateContract();

        ValidationResults = ValidationResults.Success ? valid : ValidationResults;
    }

    public override ContractResults ExecuteContract()
    {
        if (!ValidationResults.Success)
        {
            return new ContractFailure(
                ErrorMessage: ValidationResults?.ErrorMessage ?? "Unknown error");
        }

        int totalHarvestedOre = 0;
        int timeLeft = ContractTime;
        int totalTripTime = (TimeToField * 2) + 1;
        int curCycle = 0;

        decimal totalRevenue = 0;
        decimal taxes = 0;
        decimal netProfit = 0;

        while (totalTripTime <= timeLeft)
        {
            timeLeft -= totalTripTime;
            int curCycleHarvest = HarvestCycle(curCycle);
            if (totalHarvestedOre > 0) timeLeft--;
            ContractStation.ProcessOres(new PairDataPack<Ore, decimal>(TargetAsteroidBelt.BeltOre, curCycleHarvest));
            Station.SaleReport mineralSaleReport = ContractStation.SellMinerals(PriceList);
            totalRevenue += mineralSaleReport.TotalRevenue;
            taxes += mineralSaleReport.Taxes;
            netProfit += mineralSaleReport.NetProfit;
            ContractFleet.Strategy.ClearStorages(ContractFleet.Ships);
            curCycle++;
        }

        return new ContractSuccess(
            WorkTime: ContractTime - timeLeft,
            HarvestCyclesAmount: curCycle--,
            TotalHarvestedVolume: totalHarvestedOre,
            StoragedMinerals: new Dictionary<Type, int>(),
            TotalRevenue: totalRevenue,
            TotalRent: (ContractTime - timeLeft) * ContractFleet.UpkeerPerTimeUnit,
            TaxesAmount: taxes,
            NetProfit: netProfit);
    }

    private ValidationInfo ValidateContract()
    {
        return (TimeToField * 2) + 2 <= ContractTime
        ?
            new ValidationInfo(
                Success: true,
                ErrorMessage: null)
        :
            new ValidationInfo(
                Success: false,
                ErrorMessage: "Contract time too short");
    }
}