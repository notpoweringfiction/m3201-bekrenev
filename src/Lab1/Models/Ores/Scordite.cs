namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Ores;

public record Scordite : IOre
{
    public Scordite(decimal oreVolume) : base(
        volume: oreVolume,
        volumePerUnit: 0.15m,
        refinementMineralsList: new Dictionary<Type, decimal>
        {
            [typeof(Minerals.Tritanium)] = 75m,
            [typeof(Minerals.Pyerite)] = 55m,
        })
    {
    }
}