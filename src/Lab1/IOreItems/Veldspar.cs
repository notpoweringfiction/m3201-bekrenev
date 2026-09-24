namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Veldspar : IOre
{
    public Veldspar(decimal oreVolume) : base(
        volume: oreVolume,
        volumePerUnit: 0.1m,
        refinementMineralsList: new Dictionary<Type, int>
        {
            [typeof(Tritanium)] = 200,
        })
    {
    }
}