namespace Itmo.ObjectOrientedProgramming.Lab1.Utils;

public record TaxValue : RangeDecimal
{
    public TaxValue(decimal specifiedTax) : base(specifiedTax, 0, 1)
    {
        if (specifiedTax > 1)
            throw new ArgumentException(ExceptionMessage);
        Value = specifiedTax;
    }

    protected override string ExceptionMessage => "Tax cannot out of [0,1] bounds";
}