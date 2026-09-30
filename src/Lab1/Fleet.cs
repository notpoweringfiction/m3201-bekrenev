namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Fleet
{
    public IReadOnlyCollection<IShip> Ships { get; init; }

    public IStrategy Strategy { get; init; }

    public int Speed { get; init; }

    public int UpkeerPerTimeUnit { get; init; }

    public Fleet(IReadOnlyCollection<IShip> shipsList, IStrategy fleetStrategy)
    {
        if (shipsList.Count == 0)
        {
            throw new ArgumentException("No ships in fleet");
        }

        int maxShipSpeed = 0;
        int totalUpkeep = 0;
        foreach (IShip ship in shipsList)
        {
            maxShipSpeed = Math.Min(maxShipSpeed, ship.Speed);
            totalUpkeep += ship.RentRate;
        }

        Speed = maxShipSpeed;
        Ships = shipsList;
        Strategy = fleetStrategy;
    }

    public bool CanMineFirstCycle()
    {
        foreach (IShip curShip in Ships)
        {
            if (curShip.SimulateHarvestCycle(1) > 0)
            {
                return true;
            }
        }

        return false;
    }
}