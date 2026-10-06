namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Minerals;

public record Tritanium : Mineral
{
    public override int GetHashCode()
    {
        return typeof(Tritanium).GetHashCode();
    }
}