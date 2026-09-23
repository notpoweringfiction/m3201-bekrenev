using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Scordite : IOreItem
{
    public Scordite(decimal oreVolume) : base(
        volume: oreVolume,
        volumePerUnit: 0.15m,
        refinementMineralsList: new ReadOnlyCollection<IMineralItem>(
            new List<IMineralItem>
            {
                new Tritanium(tritaniumStartQty: 75),
                new Pyerite(pyeriteStartQty: 55),
            }))
    {
    }
}