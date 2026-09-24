namespace Itmo.ObjectOrientedProgramming.Lab1;

public abstract class IOre
{
    public IReadOnlyDictionary<Type, int> RefineOutputList { get; }

    public decimal Volume { get; }

    public decimal VolumePerUnit { get; }

    protected IOre(decimal volume, decimal volumePerUnit, IReadOnlyDictionary<Type, int> refinementMineralsList)
    {
        Volume = volume;
        VolumePerUnit = volumePerUnit;

        Dictionary<Type, int> mineralDict = new();

        foreach (KeyValuePair<Type, int> pair in refinementMineralsList)
        {
            if (!typeof(IMineral).IsAssignableFrom(pair.Key))
            {
                mineralDict.Add(pair.Key, pair.Value);
            }
        }

        RefineOutputList = mineralDict;
    }
}