namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Minerals;

public record Isogen() : Mineral
{
    public override int GetHashCode()
    {
        return typeof(Isogen).GetHashCode();
    }
}