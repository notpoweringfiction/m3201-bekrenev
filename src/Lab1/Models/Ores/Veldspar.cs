namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Ores;

public record Veldspar : Ore
{
    public Veldspar() : base(
        volumePerUnit: 0.1m,
        refinementMineralsList: new Dictionary<Type, decimal>
        {
            [typeof(Minerals.Tritanium)] = 200m,
        })
    {
    }
}