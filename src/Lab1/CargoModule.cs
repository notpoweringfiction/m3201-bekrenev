using Itmo.ObjectOrientedProgramming.Lab1.Utils;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class CargoModule
{
    public NonNegativeInt MaxCargoStorage { get; init; }

    public int StorageLeft { get; private set; }

    public CargoModule(NonNegativeInt maxCargoHold)
    {
        MaxCargoStorage = maxCargoHold;
        StorageLeft = maxCargoHold.Value;
    }

    public int StoreCargo(NonNegativeInt cargoAmount)
    {
        int stored = Math.Min(cargoAmount.Value, StorageLeft);
        StorageLeft -= stored;
        return stored;
    }

    public void ClearStorage()
    {
        StorageLeft = MaxCargoStorage.Value;
    }
}