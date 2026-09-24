namespace Itmo.ObjectOrientedProgramming.Lab1;

public abstract class IOre
{
    public IReadOnlyDictionary<Type, int> RefineOutputList { get; }

    public decimal Volume { get; }

    public decimal VolumePerUnit { get; }

    protected IOre(decimal volume, decimal volumePerUnit, IReadOnlyDictionary<Type, int> refinementMineralsList)
    {
        if (volume < 0 || volumePerUnit < 0)
        {
            throw new ArgumentException("Negative volume or volume per point")
        }

        Dictionary<Type, int> mineralDict = new();

        foreach (KeyValuePair<Type, int> pair in refinementMineralsList)
        {
            if (pair.Value < 0)
            {
                throw new ArgumentException("Negative mineral output");
            }

            if (!typeof(IMineral).IsAssignableFrom(pair.Key))
            {
                mineralDict.Add(pair.Key, pair.Value);
            }
        }

        Volume = volume;
        VolumePerUnit = volumePerUnit;

        RefineOutputList = mineralDict;
    }
}