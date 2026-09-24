namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Scordite : IOre
{
    public Scordite(decimal oreVolume) : base(
        volume: oreVolume,
        volumePerUnit: 0.15m,
        refinementMineralsList: new Dictionary<Type, int>
        {
            [typeof(Tritanium)] = 75,
            [typeof(Pyerite)] = 55,
        })
    {
    }
}