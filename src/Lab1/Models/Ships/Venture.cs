namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Venture : Ship
{
    public const int HarvestVolume = 100;

    public Venture() : base(maxCargoHold: 400, maxSpeed: 4, rentRate: 1000)
    {
    }

    public override int SimulateHarvestCycle(int simCycle)
    {
        return HarvestVolume;
    }
}