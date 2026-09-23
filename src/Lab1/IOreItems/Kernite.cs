using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Kernite : IOreItem
{
    public Kernite(decimal oreVolume) : base(
        volume: oreVolume,
        volumePerUnit: 1.2m,
        refinementMineralsList: new ReadOnlyCollection<IMineralItem>(
            new List<IMineralItem>
            {
                new Mexallon(mexallonStartQty: 30),
                new Isogen(isogenStartQty: 60),
            }))
    {
    }
}