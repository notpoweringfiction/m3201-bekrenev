namespace Itmo.ObjectOrientedProgramming.Lab1;

/// <summary>
/// Например, класс реализующий процесс расчётов.
/// </summary>
public class Calculator
{
    public record MappedContractResults(
        int WorkTime,
        int HarvestCyclesAmount,
        decimal TotalHarvestedVolume,
        IReadOnlyDictionary<Type, int> StoragedOre,
        IReadOnlyDictionary<Type, int> SoldMinerals,
        decimal TotalRevenue,
        decimal TotalRent,
        decimal TaxesAmount,
        decimal NetProfit);

    public record CalculationResult
    {
    }

    public record CalculationSuccess(MappedContractResults Results) : CalculationResult
    {
    }

    public record CalculationFailure(ContractError Error) : CalculationResult
    {
    }

    public CalculationResult Calculate(Contract contract)
    {
        Contract.ContractResults results = contract.ExecuteContract();

        return results switch
        {
            Contract.ContractSuccess success => new CalculationSuccess(MapContractResults(success)),

            Contract.ContractFailure failure => new CalculationFailure(failure.Error),

            _ => new CalculationFailure(new UnknownError("Unknown contract output")),
        };
    }

    private MappedContractResults MapContractResults(Contract.ContractSuccess unmappedResults)
    {
        return new(
            WorkTime: unmappedResults.WorkTime,
            HarvestCyclesAmount: unmappedResults.HarvestCyclesAmount,
            TotalHarvestedVolume: unmappedResults.TotalHarvestedVolume,
            StoragedOre: unmappedResults.StoragedOre,
            SoldMinerals: unmappedResults.SoldMinerals,
            TotalRevenue: unmappedResults.TotalRevenue,
            TotalRent: unmappedResults.TotalRent,
            TaxesAmount: unmappedResults.TaxesAmount,
            NetProfit: unmappedResults.NetProfit);
    }
}