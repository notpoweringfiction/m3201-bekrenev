namespace Itmo.ObjectOrientedProgramming.Lab1;

public class CargoModule
{
    public IReadOnlyDictionary<Type, int> CargoStorage { get; } = new Dictionary<Type, int>();

    public int MaxCargoStorage { get; }

    public int StorageLeft { get; }

    public CargoModule(int maxCargoHold)
    {
        if (maxCargoHold < 0)
        {
            throw new ArgumentException("Negative max cargo hold");
        }

        MaxCargoStorage = maxCargoHold;
    }
}