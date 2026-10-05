using MutableOrePair = Itmo.ObjectOrientedProgramming.Lab1.MutablePairPack<Itmo.ObjectOrientedProgramming.Lab1.Ore, int>;
using OreDataPair = Itmo.ObjectOrientedProgramming.Lab1.PairDataPack<Itmo.ObjectOrientedProgramming.Lab1.Ore, int>;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Station
{
    public IDictionary<Type, MutableOrePair> OreStorage { get; private set; }

    private decimal TaxRate { get; init; }

    public record SaleReport(
        decimal NetProfit,
        decimal TotalRevenue,
        decimal Taxes,
        IReadOnlyDictionary<Type, int> SoldMinerals);

    public Station(decimal taxRate)
    {
        if (taxRate <= 1 && taxRate >= 0)
        {
            throw new ArgumentException("Tax rate beyond [0, 1]");
        }

        TaxRate = taxRate;
        OreStorage = new Dictionary<Type, MutableOrePair>();
    }

    public void ProcessOres(Type oreType, OreDataPair oreInput)
    {
        OreStorage.TryAdd(oreType, new MutableOrePair(oreInput.First, 0));
        OreStorage[oreType].Second += (int)(oreInput.Second / oreInput.First.VolumePerUnit);
    }

    public SaleReport SellMinerals(MineralPriceData priceList)
    {
        int totalRevenue = 0;

        Dictionary<Type, int> soldMinerals = new();

        foreach (KeyValuePair<Type, MutableOrePair> pair in OreStorage)
        {
            int portionAmount = pair.Value.Second / 100;

            foreach (KeyValuePair<Type, int> mineralPair in pair.Value.First.RefineOutputList)
            {
                totalRevenue += priceList.PriceList[mineralPair.Key] * portionAmount * mineralPair.Value;
                soldMinerals.TryAdd(mineralPair.Key, 0);
                soldMinerals[mineralPair.Key] += portionAmount * mineralPair.Value;
            }

            pair.Value.Second -= portionAmount * 100;
        }

        return new SaleReport(totalRevenue * (1 - TaxRate), totalRevenue, totalRevenue * TaxRate, soldMinerals);
    }

    public void ClearStorage()
    {
        OreStorage.Clear();
    }
}