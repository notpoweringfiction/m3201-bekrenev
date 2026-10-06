namespace Itmo.ObjectOrientedProgramming.Lab1;

public class MineralPriceData
{
    public IReadOnlyDictionary<Type, int> Value { get; init; }

    public MineralPriceData(IDictionary<Type, int> newPriceList)
    {
        Dictionary<Type, int> finalPriceList = new();

        foreach (KeyValuePair<Type, int> pair in newPriceList)
        {
            if (!pair.Key.IsAssignableTo(typeof(Mineral)))
                throw new ArgumentException("Type is not descendant of Mineral");
            finalPriceList.Add(pair.Key, pair.Value);
        }

        Value = finalPriceList;
    }
}