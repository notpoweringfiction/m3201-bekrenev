using Itmo.ObjectOrientedProgramming.Lab1.Utils;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Epithal : Ship
{
    public Epithal() : base(new CargoModule(new NonNegativeInt(3000)), new SpeedValue(2), new RentValue(500))
    {
    }

    public override int SimulateHarvestCycle(int simCycle)
    {
        return 0;
    }
}