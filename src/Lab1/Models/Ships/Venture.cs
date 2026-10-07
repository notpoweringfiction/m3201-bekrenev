using Itmo.ObjectOrientedProgramming.Lab1.Utils;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Venture : ShipModel
{
    public const int HarvestVolume = 100;

    public Venture() : base(new SpeedValue(4), new RentValue(1000), new NonNegativeInt(400))
    {
    }

    public override int SimulateHarvestCycle(int simCycle)
    {
        return HarvestVolume;
    }
}