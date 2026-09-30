namespace Itmo.ObjectOrientedProgramming.Lab1;

public abstract class IContract
{
    public record ContractResults
    (
        int WorkTime,
        int HarvestCyclesAmount,
        decimal TotalHarvestedVolume,
        IReadOnlyDictionary<Type, int> StoragedMinerals,
        decimal TotalRevenue,
        decimal TotalRent,
        decimal TaxesAmount,
        decimal NetProfit)
    {
    }

    public AsteroidBelt TargetAsteroidBelt { get; init; }

    public Fleet ContractFleet { get; init; }

    public MineralPriceData PriceList { get; init; }

    public Station ContractStation { get; }

    protected IContract(AsteroidBelt selectedBelt, Fleet selectedFleet, MineralPriceData givenPriceData, Station contractStation)
    {
        PriceList = givenPriceData;
        TargetAsteroidBelt = selectedBelt;
        ContractFleet = selectedFleet;
        ContractStation = contractStation;
    }

    public abstract ContractResults ExecuteContract();
}