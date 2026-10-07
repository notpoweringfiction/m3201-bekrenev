using Itmo.ObjectOrientedProgramming.Lab1.Utils;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public abstract class ShipModel
{
    public SpeedValue Speed { get; init; }

    public RentValue RentRate { get; init; }

    public NonNegativeInt MaxCargoVolume { get; init; }

    protected ShipModel(SpeedValue maxSpeed, RentValue rentRate, NonNegativeInt maxCargo)
    {
        Speed = maxSpeed;
        RentRate = rentRate;
        MaxCargoVolume = maxCargo;
    }

    public abstract int SimulateHarvestCycle(int simCycle);
}