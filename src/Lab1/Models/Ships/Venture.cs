using Itmo.ObjectOrientedProgramming.Lab1.Utils;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Venture : Ship
{
    public const int HarvestVolume = 100;

    public Venture() : base(new CargoModule(new NonNegativeInt(400)), new SpeedValue(4), new RentValue(1000))
    {
    }

    public override int SimulateHarvestCycle(int simCycle)
    {
        return HarvestVolume;
    }
}