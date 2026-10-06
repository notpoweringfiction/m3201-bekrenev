using Itmo.ObjectOrientedProgramming.Lab1.Models.Minerals;
using Itmo.ObjectOrientedProgramming.Lab1.Utils;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Ores;

public record Veldspar : Ore
{
    public Veldspar() : base(
        volumePerUnit: new VolumeValue(0.1m),
        refinementMineralsList: new Dictionary<Mineral, NonNegativeInt>
        {
            [new Tritanium()] = new NonNegativeInt(200),
        })
    {
    }
}