namespace Itmo.ObjectOrientedProgramming.Lab1;

public record FleetError(string ErrorMessage) : ContractError(ErrorMessage);