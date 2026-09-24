namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Pyroxeres : IOre
{
    public Pyroxeres(decimal oreVolume) : base(
        volume: oreVolume,
        volumePerUnit: 0.3m,
        refinementMineralsList: new Dictionary<Type, int>
        {
            [typeof(Pyerite)] = 45,
            [typeof(Mexallon)] = 15,
        })
    {
    }
}