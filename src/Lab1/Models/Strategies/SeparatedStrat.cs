namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Strategies;

public class SeparatedStrat : Strategy
{
    public override bool TryStoringOre(int oreToStore, Ship curShip, IReadOnlyCollection<Ship> shipsList)
    {
        if (!CanStoreOre(oreToStore, curShip, shipsList)) return false;

        curShip.CargoHold.StoreCargo(oreToStore);
        return true;
    }

    private bool CanStoreOre(int oreToStore, Ship curShip, IReadOnlyCollection<Ship> shipsList)
    {
        int oreLeftToStore = oreToStore;

        oreLeftToStore = Math.Max(oreLeftToStore - curShip.CargoHold.StorageLeft, 0);

        return oreLeftToStore == 0;
    }
}