namespace Itmo.ObjectOrientedProgramming.Lab1;

public record UnknownError(string ErrorMessage) : ContractError(ErrorMessage);