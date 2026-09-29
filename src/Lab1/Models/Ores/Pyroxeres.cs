namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Ores;

public record Pyroxeres : IOre
{
    public Pyroxeres(decimal oreVolume) : base(
        volume: oreVolume,
        volumePerUnit: 0.3m,
        refinementMineralsList: new Dictionary<Type, int>
        {
            [typeof(Minerals.Pyerite)] = 45,
            [typeof(Minerals.Mexallon)] = 15,
        })
    {
    }
}