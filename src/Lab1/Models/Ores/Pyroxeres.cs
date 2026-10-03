namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Ores;

public record Pyroxeres : Ore
{
    public Pyroxeres() : base(
        volumePerUnit: 0.3m,
        refinementMineralsList: new Dictionary<Type, int>
        {
            [typeof(Minerals.Pyerite)] = 45,
            [typeof(Minerals.Mexallon)] = 15,
        })
    {
    }
}