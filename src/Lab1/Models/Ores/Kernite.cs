namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Ores;

public record Kernite : IOre
{
    public Kernite(decimal oreVolume) : base(
        volume: oreVolume,
        volumePerUnit: 1.2m,
        refinementMineralsList: new Dictionary<Type, decimal>
        {
            [typeof(Minerals.Mexallon)] = 30m,
            [typeof(Minerals.Isogen)] = 60m,
        })
    {
    }
}