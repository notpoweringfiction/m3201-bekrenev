namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Fleet
{
    public IReadOnlyCollection<IShip> Ships { get; }

    public IStrategy Strategy { get; }

    public int FleetSpeed { get; }

    public Fleet(IReadOnlyCollection<IShip> shipsList, IStrategy fleetStrategy)
    {
        if (shipsList.Count == 0)
        {
            throw new ArgumentException("No ships in fleet");
        }

        Ships = shipsList.ToList();
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