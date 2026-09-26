namespace Itmo.ObjectOrientedProgramming.Lab1;

public class SeparatedStrat : IStrategy
{
    public override bool CanStoreOre(int oreToStore, IShip curShip, IReadOnlyCollection<IShip> shipsList)
    {
        int oreLeftToStore = oreToStore;

        oreLeftToStore = Math.Max(oreLeftToStore - curShip.CargoHold.StorageLeft, 0);

        return oreLeftToStore == 0;
    }
}