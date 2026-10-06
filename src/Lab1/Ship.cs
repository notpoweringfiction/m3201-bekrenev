using Itmo.ObjectOrientedProgramming.Lab1.Utils;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public abstract class Ship
{
    public CargoModule CargoHold { get; }

    public SpeedValue Speed { get; init; }

    public RentValue RentRate { get; init; }

    protected Ship(CargoModule cargoModule, SpeedValue maxSpeed, RentValue rentRate)
    {
        CargoHold = cargoModule;
        Speed = maxSpeed;
        RentRate = rentRate;
    }

    public abstract int SimulateHarvestCycle(int simCycle);
}