using Itmo.ObjectOrientedProgramming.Lab1.Models.Minerals;
using Itmo.ObjectOrientedProgramming.Lab1.Utils;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Ores;

public record Scordite : Ore
{
    public Scordite() : base(
        volumePerUnit: new VolumeValue(0.15m),
        refinementMineralsList: new Dictionary<Mineral, NonNegativeInt>
        {
            [new Tritanium()] = new NonNegativeInt(75),
            [new Pyerite()] = new NonNegativeInt(55),
        })
    {
    }
}