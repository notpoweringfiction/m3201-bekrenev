using Itmo.ObjectOrientedProgramming.Lab1.Models.Minerals;
using Itmo.ObjectOrientedProgramming.Lab1.Utils;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Ores;

public record Pyroxeres : Ore
{
    public Pyroxeres() : base(
        volumePerUnit: new VolumeValue(0.3m),
        refinementMineralsList: new Dictionary<Mineral, NonNegativeInt>
        {
            [new Pyerite()] = new NonNegativeInt(45),
            [new Mexallon()] = new NonNegativeInt(15),
        })
    {
    }
}