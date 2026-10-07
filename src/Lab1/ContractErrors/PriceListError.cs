namespace Itmo.ObjectOrientedProgramming.Lab1;

public record PriceListError(string ErrorMessage) : ContractError(ErrorMessage);