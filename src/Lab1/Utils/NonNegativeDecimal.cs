namespace Itmo.ObjectOrientedProgramming.Lab1.Utils;

public record NonNegativeDecimal
{
    public decimal Value { get; }

    public NonNegativeDecimal(decimal specifiedValue)
    {
        if (specifiedValue < 0)
        {
            throw new ArgumentException(ExceptionMessage);
        }

        Value = specifiedValue;
    }

    protected virtual string ExceptionMessage => "Value cannot be negative";
}