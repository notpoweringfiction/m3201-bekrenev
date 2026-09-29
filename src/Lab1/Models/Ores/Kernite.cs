namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Ores;

public record Kernite : IOre
{
    public Kernite(decimal oreVolume) : base(
        volume: oreVolume,
        volumePerUnit: 1.2m,
        refinementMineralsList: new Dictionary<Type, int>
        {
            [typeof(Minerals.Mexallon)] = 30,
            [typeof(Minerals.Isogen)] = 60,
        })
    {
    }
}