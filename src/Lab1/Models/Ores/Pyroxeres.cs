namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Ores;

public record Pyroxeres : IOre
{
    public Pyroxeres(decimal oreVolume) : base(
        volume: oreVolume,
        volumePerUnit: 0.3m,
        refinementMineralsList: new Dictionary<Type, decimal>
        {
            [typeof(Minerals.Pyerite)] = 45m,
            [typeof(Minerals.Mexallon)] = 15m,
        })
    {
    }
}