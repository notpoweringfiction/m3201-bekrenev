using Itmo.ObjectOrientedProgramming.Lab1.Utils;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Epithal : ShipModel
{
    public Epithal() : base(new SpeedValue(2), new RentValue(500), new NonNegativeInt(3000))
    {
    }

    public override int SimulateHarvestCycle(int simCycle)
    {
        return 0;
    }
}