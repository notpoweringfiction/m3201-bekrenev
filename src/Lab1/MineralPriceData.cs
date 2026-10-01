namespace Itmo.ObjectOrientedProgramming.Lab1;

public class MineralPriceData
{
    public IReadOnlyDictionary<Type, int> PriceList { get; init; }

    public MineralPriceData(IDictionary<Type, int> newPriceList)
    {
        Dictionary<Type, int> finalPriceList = new();

        foreach (KeyValuePair<Type, int> pair in newPriceList)
        {
            if (!pair.Key.IsAssignableTo(typeof(Mineral)) || pair.Value < 0)
            {
                Console.Error.WriteLine("Entry with type " + pair.Key.ToString() + " in price list skipped due to negative price or type not inherited from IMineral");
                continue;
            }

            finalPriceList.Add(pair.Key, pair.Value);
        }

        PriceList = finalPriceList;
    }
}