namespace Itmo.ObjectOrientedProgramming.Lab1;

/// <summary>
/// Например, класс реализующий процесс расчётов.
/// </summary>
public class Calculator
{
    public record CalculationResult
    {
    }

    public record CalculationSuccess(Contract.ContractResults Results) : CalculationResult
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
            Contract.ContractSuccess success => new CalculationSuccess(success),

            Contract.ContractFailure failure => new CalculationFailure(failure.Error),

            _ => new CalculationFailure(new UnknownError("Unknown contract output")),
        };
    }
}