namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Prospect : Ship
{
    public const int FirstCycleHarvestVolume = 75;

    public const int NormalHarvestVolume = 150;

    public Prospect() : base(maxCargoHold: 1000, maxSpeed: 5, rentRate: 1500)
    {
    }

    public override int SimulateHarvestCycle(int simCycle)
    {
        return simCycle > 0 ? NormalHarvestVolume : FirstCycleHarvestVolume;
    }
}