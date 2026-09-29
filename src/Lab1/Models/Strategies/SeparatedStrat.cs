namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Strategies;

public class SeparatedStrat : IStrategy
{
    public override bool TryStoringOre(int oreToStore, IShip curShip, IReadOnlyCollection<IShip> shipsList)
    {
        if (!CanStoreOre(oreToStore, curShip, shipsList)) return false;

        curShip.CargoHold.StoreCargo(oreToStore);
        return true;
    }

    private bool CanStoreOre(int oreToStore, IShip curShip, IReadOnlyCollection<IShip> shipsList)
    {
        int oreLeftToStore = oreToStore;

        oreLeftToStore = Math.Max(oreLeftToStore - curShip.CargoHold.StorageLeft, 0);

        return oreLeftToStore == 0;
    }
}