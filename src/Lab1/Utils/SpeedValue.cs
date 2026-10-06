namespace Itmo.ObjectOrientedProgramming.Lab1.Utils;

public record SpeedValue : NonNegativeInt
{
    public SpeedValue(int specifiedSpeed) : base(specifiedSpeed)
    {
    }

    protected override string ExceptionMessage => "Speed cannot be negative";
}