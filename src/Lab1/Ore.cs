namespace Itmo.ObjectOrientedProgramming.Lab1;

public abstract record Ore
{
    public IReadOnlyDictionary<Type, int> RefineOutputList { get; }

    public decimal VolumePerUnit { get; }

    protected Ore(decimal volumePerUnit, IReadOnlyDictionary<Type, int> refinementMineralsList)
    {
        if (volumePerUnit < 0)
        {
            throw new ArgumentException("Negative volume per point");
        }

        Dictionary<Type, int> mineralDict = new();

        foreach (KeyValuePair<Type, int> pair in refinementMineralsList)
        {
            if (pair.Value < 0)
            {
                throw new ArgumentException("Negative mineral output");
            }

            if (pair.Key.IsAssignableTo(typeof(Mineral)))
            {
                mineralDict.Add(pair.Key, pair.Value);
            }
        }

        VolumePerUnit = volumePerUnit;

        RefineOutputList = mineralDict;
    }
}