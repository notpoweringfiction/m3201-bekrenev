namespace Itmo.ObjectOrientedProgramming.Lab1.Utils;

public record RentValue : NonNegativeInt
{
    public RentValue(int specifiedRent) : base(specifiedRent)
    {
    }

    protected override string ExceptionMessage => "Rent cannot be negative";
}