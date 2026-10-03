namespace Itmo.ObjectOrientedProgramming.Lab1;

public class CargoModule
{
    public int MaxCargoStorage { get; init; }

    public int StorageLeft { get; private set; }

    public CargoModule(int maxCargoHold)
    {
        if (maxCargoHold < 0)
        {
            throw new ArgumentException("Negative max cargo hold");
        }

        MaxCargoStorage = maxCargoHold;
        StorageLeft = maxCargoHold;
    }

    public int StoreCargo(int cargoAmount)
    {
        if (cargoAmount < 0) return 0;
        int stored = Math.Min(cargoAmount, StorageLeft);
        StorageLeft -= stored;
        return stored;
    }

    public void ClearStorage()
    {
        StorageLeft = MaxCargoStorage;
    }
}