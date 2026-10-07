namespace Itmo.ObjectOrientedProgramming.Lab1;

public abstract class Strategy
{
    public abstract bool TryStoringOre(int oreToStore, Ship curShip, IReadOnlyCollection<Ship> shipsList);

    public void ClearStorages(IReadOnlyCollection<Ship> ships)
    {
        foreach (Ship ship in ships)
        {
            ship.CargoHold.ClearStorage();
        }
    }
}