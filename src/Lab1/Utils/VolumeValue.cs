namespace Itmo.ObjectOrientedProgramming.Lab1.Utils;

public record VolumeValue : NonNegativeDecimal
{
    public VolumeValue(decimal specifiedVolume) : base(specifiedVolume)
    {
    }

    protected override string ExceptionMessage => "Volume cannot be negative";
}