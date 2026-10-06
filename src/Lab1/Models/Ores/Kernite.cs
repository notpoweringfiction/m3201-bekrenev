using Itmo.ObjectOrientedProgramming.Lab1.Models.Minerals;
using Itmo.ObjectOrientedProgramming.Lab1.Utils;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Ores;

public record Kernite : Ore
{
    public Kernite() : base(
        volumePerUnit: new VolumeValue(1.2m),
        refinementMineralsList: new Dictionary<Mineral, NonNegativeInt>
        {
            [new Mexallon()] = new NonNegativeInt(30),
            [new Isogen()] = new NonNegativeInt(60),
        })
    {
    }
}