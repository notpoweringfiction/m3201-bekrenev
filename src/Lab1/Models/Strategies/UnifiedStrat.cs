namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Strategies;

public class UnifiedStrat : IStrategy
{
    public override bool TryStoringOre(int oreToStore, IShip curShip, IReadOnlyCollection<IShip> shipsList)
    {
        if (!CanStoreOre(oreToStore, curShip, shipsList)) return false;

        foreach (IShip ship in shipsList)
        {
            int stored = ship.CargoHold.StoreCargo(oreToStore);
            oreToStore -= stored;
        }

        return true;
    }

    private bool CanStoreOre(int oreToStore, IShip curShip, IReadOnlyCollection<IShip> shipsList)
    {
        int oreLeftToStore = oreToStore;

        foreach (IShip ship in shipsList)
        {
            oreLeftToStore = Math.Max(oreLeftToStore - ship.CargoHold.StorageLeft, 0);
        }

        return oreLeftToStore == 0;
    }
}