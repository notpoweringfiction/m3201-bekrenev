namespace Itmo.ObjectOrientedProgramming.Lab1;

public abstract class IContract
{
    public record ExecutionResults
    (
        bool Success,
        string? ErrorMessage,
        ContractResults? Results)
    {
    }

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

    public ValidationInfo ValidationResults { get; init; }

    protected IContract(AsteroidBelt selectedBelt, Fleet selectedFleet, MineralPriceData givenPriceData, Station contractStation)
    {
        PriceList = givenPriceData;
        TargetAsteroidBelt = selectedBelt;
        ContractFleet = selectedFleet;
        ContractStation = contractStation;
        ValidationResults = ValidateContract();
    }

    public abstract ExecutionResults ExecuteContract();

    public record ValidationInfo(
        bool Success,
        string? ErrorMessage)
    {
    }

    private ValidationInfo ValidateContract()
    {
        if (!ContractFleet.CanMineFirstCycle())
        {
            return new ValidationInfo(
                Success: false,
                ErrorMessage: "Fleet can't mine first cycle");
        }

        foreach (KeyValuePair<Type, int> mineralOutput in TargetAsteroidBelt.BeltOre.RefineOutputList)
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