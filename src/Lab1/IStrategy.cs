namespace Itmo.ObjectOrientedProgramming.Lab1;

public abstract class IStrategy
{
    public abstract bool CanStoreOre(int oreToStore, IShip curShip, IReadOnlyCollection<IShip> shipsList);
}