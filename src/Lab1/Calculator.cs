namespace Itmo.ObjectOrientedProgramming.Lab1;

/// <summary>
/// Например, класс реализующий процесс расчётов.
/// </summary>
public class Calculator
{
    public record CalculationResult
    {
        public record Success(Contract.ContractResults Results) : CalculationResult
        {
        }

        public record Failure(string ErrorMessage) : CalculationResult
        {
        }
    }

    public CalculationResult Calculate(Contract contract)
    {
        Contract.ContractResults results = contract.ExecuteContract();

        return results switch
        {
            Contract.ContractSuccess success => new CalculationResult.Success(success),

            Contract.ContractFailure failure => new CalculationResult.Failure(failure.ErrorMessage),

            _ => new CalculationResult.Failure("Unknown contract output"),
        };
    }
}