using Itmo.ObjectOrientedProgramming.Lab1.Utils;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Station
{
    public IReadOnlyDictionary<TypedValue<Ore>, int> OreStorage { get; }

    private readonly Dictionary<TypedValue<Ore>, int> _oreStorage;

    private TaxValue TaxRate { get; init; }

    public record SaleReport(
        decimal NetProfit,
        decimal TotalRevenue,
        decimal Taxes,
        IReadOnlyDictionary<TypedValue<Mineral>, int> SoldMinerals);

    public Station(TaxValue taxRate)
    {
        TaxRate = taxRate;
        _oreStorage = new Dictionary<TypedValue<Ore>, int>();
        OreStorage = _oreStorage;
    }

    public void ProcessOres(TypedValue<Ore> oreInput, NonNegativeInt volume)
    {
        _oreStorage.TryAdd(oreInput, 0);
        _oreStorage[oreInput] += (int)(volume.Value / oreInput.Instance.VolumePerUnit.Value);
    }

    public SaleReport SellMinerals(MineralPriceData priceList)
    {
        int totalRevenue = 0;

        Dictionary<TypedValue<Mineral>, int> soldMinerals = new();

        foreach (KeyValuePair<TypedValue<Ore>, int> pair in OreStorage)
        {
            int portionAmount = pair.Value / 100;

            foreach (KeyValuePair<TypedValue<Mineral>, int> mineralPair in pair.Key.Instance.RefineOutputList)
            {
                totalRevenue += priceList.Value[mineralPair.Key.ValueType] * portionAmount * mineralPair.Value;
                soldMinerals.TryAdd(new TypedValue<Mineral>(mineralPair.Key.Instance), 0);
                soldMinerals[new TypedValue<Mineral>(mineralPair.Key.Instance)] += portionAmount * mineralPair.Value;
            }

            _oreStorage[pair.Key] -= portionAmount * 100;
        }

        return new SaleReport(totalRevenue * (1 - TaxRate.Value), totalRevenue, totalRevenue * TaxRate.Value, soldMinerals);
    }

    public void ClearStorage()
    {
        _oreStorage.Clear();
    }
}