namespace Itmo.ObjectOrientedProgramming.Lab1.Utils;

public record NonNegativeInt
{
    public int Value { get; }

    public NonNegativeInt(int specifiedValue)
    {
        if (specifiedValue < 0)
        {
            throw new ArgumentException(ExceptionMessage);
        }

        Value = specifiedValue;
    }

    protected virtual string ExceptionMessage => "Value cannot be negative";
}