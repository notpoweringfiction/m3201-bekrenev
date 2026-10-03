namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Fleet
{
    public IReadOnlyCollection<Ship> Ships { get; init; }

    public Strategy Strategy { get; init; }

    public int Speed { get; init; }

    public int UpkeerPerTimeUnit { get; init; }

    public Fleet(IReadOnlyCollection<Ship> shipsList, Strategy fleetStrategy)
    {
        if (shipsList.Count == 0)
        {
            throw new ArgumentException("No ships in fleet");
        }

        int maxShipSpeed = int.MaxValue;
        int totalUpkeep = 0;
        foreach (Ship ship in shipsList)
        {
            maxShipSpeed = Math.Min(maxShipSpeed, ship.Speed);
            totalUpkeep += ship.RentRate;
        }

        UpkeerPerTimeUnit = totalUpkeep;
        Speed = maxShipSpeed;
        Ships = shipsList;
        Strategy = fleetStrategy;
    }

    public bool CanMineFirstCycle()
    {
        foreach (Ship curShip in Ships)
        {
            if (curShip.SimulateHarvestCycle(1) > 0)
            {
                return true;
            }
        }

        return false;
    }
}