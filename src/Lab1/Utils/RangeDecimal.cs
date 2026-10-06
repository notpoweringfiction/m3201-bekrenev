namespace Itmo.ObjectOrientedProgramming.Lab1.Utils;

public record RangeDecimal
{
    public decimal Value { get; set; }

    public RangeDecimal(decimal specifiedValue, decimal left, decimal right)
    {
        if (specifiedValue < left || specifiedValue > right)
            throw new ArgumentException(ExceptionMessage);
        Value = specifiedValue;
    }

    protected virtual string ExceptionMessage => "Value cannot be negative";
}