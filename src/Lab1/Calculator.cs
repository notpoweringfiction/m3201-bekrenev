namespace Itmo.ObjectOrientedProgramming.Lab1;

/// <summary>
/// Например, класс реализующий процесс расчётов.
/// </summary>
public class Calculator
{
    // private readonly ISomeDependency _firstDependency;

    /*
    // Конструктор, реализующий принципы композиции
    public Сalculator(ISomeDependency firstDependency)
    {
        _firstDependency = firstDependency;
    }
    */

    public record CalculationResult
    {
        public record Success(IContract.ContractResults Results) : CalculationResult
        {
        }

        public record Failure(string ErrorMessage) : CalculationResult
        {
        }
    }

    public CalculationResult Calculate(IContract contract)
    {
        IContract.ContractResults fallback = new(WorkTime: 0, HarvestCyclesAmount: 0, TotalHarvestedVolume: 0, StoragedMinerals: new Dictionary<Type, int>(), TotalRevenue: 0, TotalRent: 0, TaxesAmount: 0, NetProfit: 0);

        IContract.ExecutionResults results = contract.ExecuteContract();

        return results.Success ?
        new CalculationResult.Success(results?.Results ?? fallback)
        : new CalculationResult.Failure(results?.ErrorMessage ?? "Unknown error");
    }
}