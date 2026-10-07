namespace Itmo.ObjectOrientedProgramming.Lab1;

public record TimeContractError(string ErrorMessage) : ContractError(ErrorMessage);