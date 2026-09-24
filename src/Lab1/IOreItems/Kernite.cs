namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Kernite : IOre
{
    public Kernite(decimal oreVolume) : base(
        volume: oreVolume,
        volumePerUnit: 1.2m,
        refinementMineralsList: new Dictionary<Type, int>
        {
            [typeof(Mexallon)] = 30,
            [typeof(Isogen)] = 60,
        })
    {
    }
}