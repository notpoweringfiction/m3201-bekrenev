namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Minerals;

public record Mexallon() : Mineral
{
    public override int GetHashCode()
    {
        return typeof(Mexallon).GetHashCode();
    }
}