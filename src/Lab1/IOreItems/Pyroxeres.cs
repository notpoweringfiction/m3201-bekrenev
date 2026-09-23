using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Pyroxeres : IOreItem
{
    public Pyroxeres(decimal oreVolume) : base(
        volume: oreVolume,
        volumePerUnit: 0.3m,
        refinementMineralsList: new ReadOnlyCollection<IMineralItem>(
            new List<IMineralItem>
            {
                new Pyerite(pyeriteStartQty: 45),
                new Mexallon(mexallonStartQty: 15),
            }))
    {
    }
}