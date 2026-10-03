namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Strategies;

public class SharedStrat : Strategy
{
    public override bool TryStoringOre(int oreToStore, Ship curShip, IReadOnlyCollection<Ship> shipsList)
    {
        if (!CanStoreOre(oreToStore, curShip, shipsList)) return false;

        foreach (Ship ship in shipsList)
        {
            int stored = ship.CargoHold.StoreCargo(oreToStore);
            oreToStore -= stored;
        }

        return true;
    }

    private bool CanStoreOre(int oreToStore, Ship curShip, IReadOnlyCollection<Ship> shipsList)
    {
        int oreLeftToStore = oreToStore;

        foreach (Ship ship in shipsList)
        {
            Console.WriteLine("left to store: " + oreLeftToStore.ToString());
            Console.WriteLine("available: " + ship.CargoHold.StorageLeft);

            oreLeftToStore = Math.Max(oreLeftToStore - ship.CargoHold.StorageLeft, 0);
        }

        return oreLeftToStore == 0;
    }
}