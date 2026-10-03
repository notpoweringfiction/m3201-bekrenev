namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Ores;

public record Kernite : Ore
{
    public Kernite() : base(
        volumePerUnit: 1.2m,
        refinementMineralsList: new Dictionary<Type, int>
        {
            [typeof(Minerals.Mexallon)] = 30,
            [typeof(Minerals.Isogen)] = 60,
        })
    {
    }
}