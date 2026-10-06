using Itmo.ObjectOrientedProgramming.Lab1.Utils;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Fleet
{
    public IReadOnlyCollection<Ship> Ships { get; init; }

    public Strategy Strategy { get; init; }

    public SpeedValue Speed { get; init; }

    public NonNegativeInt UpkeerPerTimeUnit { get; init; }

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
            maxShipSpeed = Math.Min(maxShipSpeed, ship.Speed.Value);
            totalUpkeep += ship.RentRate.Value;
        }

        UpkeerPerTimeUnit = new NonNegativeInt(totalUpkeep);
        Speed = new SpeedValue(maxShipSpeed);
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