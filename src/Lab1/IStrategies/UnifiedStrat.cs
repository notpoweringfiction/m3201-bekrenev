namespace Itmo.ObjectOrientedProgramming.Lab1;

public class UnifiedStrat : IStrategy
{
    public override bool CanStoreOre(int oreToStore, IShip curShip, IReadOnlyCollection<IShip> shipsList)
    {
        int oreLeftToStore = oreToStore;

        oreLeftToStore = Math.Max(oreLeftToStore - curShip.CargoHold.StorageLeft, 0);

        foreach (IShip ship in shipsList)
        {
            oreLeftToStore = Math.Max(oreLeftToStore - ship.CargoHold.StorageLeft, 0);
        }

        return oreLeftToStore == 0;
    }
}