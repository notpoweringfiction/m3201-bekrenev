namespace Itmo.ObjectOrientedProgramming.Lab1;

public abstract class IShip
{
    public CargoModule CargoHold { get; }

    public int Speed { get; }

    public int RentRate { get; }

    protected IShip(int maxCargoHold, int maxSpeed, int rentRate)
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
    }

    public abstract int SimulateHarvestCycle(int simCycle);
}