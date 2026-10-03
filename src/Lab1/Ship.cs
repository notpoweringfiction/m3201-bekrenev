namespace Itmo.ObjectOrientedProgramming.Lab1;

public abstract class Ship
{
    public CargoModule CargoHold { get; }

    public int Speed { get; init; }

    public int RentRate { get; init; }

    protected Ship(int maxCargoHold, int maxSpeed, int rentRate)
    {
        if (maxSpeed < 0)
        {
            throw new ArgumentException("Negative speed");
        }

        if (rentRate < 0)
        {
            throw new ArgumentException("Negative rent cost");
        }

        CargoHold = new CargoModule(maxCargoHold);
        Speed = maxSpeed;
        RentRate = rentRate;
    }

    public abstract int SimulateHarvestCycle(int simCycle);
}