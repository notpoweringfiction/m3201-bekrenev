namespace Itmo.ObjectOrientedProgramming.Lab1;

public abstract record Ore
{
    public IReadOnlyDictionary<Type, decimal> RefineOutputList { get; init; }

    public decimal VolumePerUnit { get; init; }

    protected Ore(decimal volumePerUnit, IReadOnlyDictionary<Type, decimal> refinementMineralsList)
    {
        if (volumePerUnit < 0)
        {
            throw new ArgumentException("Negative volume per point");
        }

        Dictionary<Type, decimal> mineralDict = new();

        foreach (KeyValuePair<Type, decimal> pair in refinementMineralsList)
        {
            if (pair.Value < 0)
            {
                throw new ArgumentException("Negative mineral output");
            }

            if (!pair.Key.IsAssignableTo(typeof(Mineral)))
            {
                mineralDict.Add(pair.Key, pair.Value);
            }
        }

        VolumePerUnit = volumePerUnit;

        RefineOutputList = mineralDict;
    }
}