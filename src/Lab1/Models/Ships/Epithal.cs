namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Epithal : Ship
{
    public Epithal() : base(maxCargoHold: 3000, maxSpeed: 2, rentRate: 500)
    {
    }

    public override int SimulateHarvestCycle(int simCycle)
    {
        return 0;
    }
}