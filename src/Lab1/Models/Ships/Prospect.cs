using Itmo.ObjectOrientedProgramming.Lab1.Utils;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Prospect : Ship
{
    public const int FirstCycleHarvestVolume = 75;

    public const int NormalHarvestVolume = 150;

    public Prospect() : base(new CargoModule(new NonNegativeInt(1000)), new SpeedValue(5), new RentValue(1500))
    {
    }

    public override int SimulateHarvestCycle(int simCycle)
    {
        return simCycle > 0 ? NormalHarvestVolume : FirstCycleHarvestVolume;
    }
}