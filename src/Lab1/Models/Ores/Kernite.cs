namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Ores;

public record Kernite : Ore
{
    public Kernite() : base(
        volumePerUnit: 1.2m,
        refinementMineralsList: new Dictionary<Type, decimal>
        {
            [typeof(Minerals.Mexallon)] = 30m,
            [typeof(Minerals.Isogen)] = 60m,
        })
    {
    }
}