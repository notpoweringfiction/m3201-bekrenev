namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Ores;

public record Scordite : IOre
{
    public Scordite(decimal oreVolume) : base(
        volume: oreVolume,
        volumePerUnit: 0.15m,
        refinementMineralsList: new Dictionary<Type, int>
        {
            [typeof(Minerals.Tritanium)] = 75,
            [typeof(Minerals.Pyerite)] = 55,
        })
    {
    }
}