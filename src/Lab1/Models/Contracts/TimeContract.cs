namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Contracts;

public class TimeContract : IContract
{
    public int ContractTime { get; init; }

    private int TimeToField { get; init; }

    private int HarvestCycle(int cycleIndex)
    {
        int totalMinedOre = 0;
        foreach (IShip ship in ContractFleet.Ships)
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
    }

    public override ContractResults ExecuteContract()
    {
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
            ContractStation.ProcessOres(new PairDataPack<IOre, int>(TargetAsteroidBelt.BeltOre, curCycleHarvest));
            Station.SaleReport mineralSaleReport = ContractStation.SellMinerals(PriceList);
            totalRevenue += mineralSaleReport.TotalRevenue;
            taxes += mineralSaleReport.Taxes;
            netProfit += mineralSaleReport.NetProfit;
            curCycle++;
        }

        return new ContractResults(
            WorkTime: ContractTime - timeLeft,
            HarvestCyclesAmount: curCycle--,
            TotalHarvestedVolume: totalHarvestedOre,
            StoragedMinerals: new Dictionary<Type, int>(),
            TotalRevenue: totalRevenue,
            TotalRent: (ContractTime - timeLeft) * ContractFleet.UpkeerPerTimeUnit,
            TaxesAmount: taxes,
            NetProfit: netProfit);
    }
}