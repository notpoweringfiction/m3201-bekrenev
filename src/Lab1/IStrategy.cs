namespace Itmo.ObjectOrientedProgramming.Lab1;

public abstract class IStrategy
{
    public abstract bool TryStoringOre(int oreToStore, IShip curShip, IReadOnlyCollection<IShip> shipsList);

    public void ClearStorages(IReadOnlyCollection<IShip> ships)
    {
        foreach (IShip ship in ships)
        {
            ship.CargoHold.ClearStorage();
        }
    }
}