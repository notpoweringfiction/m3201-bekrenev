using System.Collections.ObjectModel;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Veldspar : IOreItem
{
    public Veldspar(decimal oreVolume) : base(
        volume: oreVolume,
        volumePerUnit: 0.1m,
        refinementMineralsList: new ReadOnlyCollection<IMineralItem>(
            new List<IMineralItem>
            {
                new Tritanium(tritaniumStartQty: 200),
            }))
    {
    }
}