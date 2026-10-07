namespace Itmo.ObjectOrientedProgramming.Lab1.Utils;

public record DistanceValue : NonNegativeInt
{
    public DistanceValue(int specifiedDistance) : base(specifiedDistance)
    {
    }

    protected override string ExceptionMessage => "Distance cannot be negative";
}