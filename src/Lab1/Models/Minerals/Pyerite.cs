namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Minerals;

public record Pyerite : Mineral
{
    public override int GetHashCode()
    {
        return typeof(Pyerite).GetHashCode();
    }
}