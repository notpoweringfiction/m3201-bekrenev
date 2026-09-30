namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Ores;

public record Veldspar : IOre
{
    public Veldspar(decimal oreVolume) : base(
        volume: oreVolume,
        volumePerUnit: 0.1m,
        refinementMineralsList: new Dictionary<Type, decimal>
        {
            [typeof(Minerals.Tritanium)] = 200m,
        })
    {
    }
}