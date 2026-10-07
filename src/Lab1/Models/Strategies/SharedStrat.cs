using Itmo.ObjectOrientedProgramming.Lab1.Utils;

namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Strategies;

public class SharedStrat : Strategy
{
    public override bool TryStoringOre(int oreToStore, Ship curShip, IReadOnlyCollection<Ship> shipsList)
    {
        if (!CanStoreOre(oreToStore, curShip, shipsList)) return false;

        foreach (Ship ship in shipsList)
        {
            int stored = ship.CargoHold.StoreCargo(new NonNegativeInt(oreToStore));
            oreToStore -= stored;
        }

        return true;
    }

    private bool CanStoreOre(int oreToStore, Ship curShip, IReadOnlyCollection<Ship> shipsList)
    {
        int oreLeftToStore = oreToStore;

        foreach (Ship ship in shipsList)
        {
            oreLeftToStore = Math.Max(oreLeftToStore - ship.CargoHold.StorageLeft, 0);
        }

        return oreLeftToStore == 0;
    }
}