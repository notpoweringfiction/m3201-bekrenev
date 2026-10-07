using Itmo.ObjectOrientedProgramming.Lab1.Utils;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public abstract record Ore
{
    public IReadOnlyDictionary<TypedValue<Mineral>, int> RefineOutputList { get; init; }

    public VolumeValue VolumePerUnit { get; init; }

    protected Ore(VolumeValue volumePerUnit, IReadOnlyDictionary<Mineral, NonNegativeInt> refinementMineralsList)
    {
        Dictionary<TypedValue<Mineral>, int> mineralDict = new();

        foreach (KeyValuePair<Mineral, NonNegativeInt> pair in refinementMineralsList)
        {
            mineralDict.Add(new TypedValue<Mineral>(pair.Key), pair.Value.Value);
        }

        VolumePerUnit = volumePerUnit;

        RefineOutputList = mineralDict;
    }
}