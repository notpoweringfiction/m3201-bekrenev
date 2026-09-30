namespace Itmo.ObjectOrientedProgramming.Lab1;

public abstract record class IOre
{
    public IReadOnlyDictionary<Type, decimal> RefineOutputList { get; init; }

    public decimal Volume { get; init; }

    public decimal VolumePerUnit { get; init; }

    protected IOre(decimal volume, decimal volumePerUnit, IReadOnlyDictionary<Type, decimal> refinementMineralsList)
    {
        if (volume < 0 || volumePerUnit < 0)
        {
            throw new ArgumentException("Negative volume or volume per point");
        }

        Dictionary<Type, decimal> mineralDict = new();

        foreach (KeyValuePair<Type, decimal> pair in refinementMineralsList)
        {
            if (pair.Value < 0)
            {
                throw new ArgumentException("Negative mineral output");
            }

            if (!pair.Key.IsAssignableTo(typeof(IMineral)))
            {
                mineralDict.Add(pair.Key, pair.Value);
            }
        }

        Volume = volume;
        VolumePerUnit = volumePerUnit;

        RefineOutputList = mineralDict;
    }
}