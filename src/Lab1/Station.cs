using MutableOrePair = Itmo.ObjectOrientedProgramming.Lab1.MutablePairPack<Itmo.ObjectOrientedProgramming.Lab1.Ore, int>;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Station
{
    public IDictionary<Type, MutableOrePair> OreStorage { get; private set; }

    private decimal TaxRate { get; init; }

    public record SaleReport
    {
        public decimal NetProfit { get; init; }

        public decimal TotalRevenue { get; init; }

        public decimal Taxes { get; init; }

        public SaleReport(decimal netProfit, decimal totalRevenue, decimal taxes)
        {
            NetProfit = netProfit;
            TotalRevenue = totalRevenue;
            Taxes = taxes;
        }
    }

    public Station(decimal taxRate)
    {
        TaxRate = taxRate;
        OreStorage = new Dictionary<Type, MutableOrePair>();
    }

    public void ProcessOres(Type oreType, MutableOrePair oreInput)
    {
        OreStorage.TryAdd(oreType, new MutableOrePair(oreInput.First, oreInput.Second));
        OreStorage[oreType].Second += (int)(oreInput.Second * oreInput.First.VolumePerUnit);
    }

    public SaleReport SellMinerals(MineralPriceData priceList)
    {
        int total_revenue = 0;

        foreach (KeyValuePair<Type, MutableOrePair> pair in OreStorage)
        {
            int portionAmount = pair.Value.Second / 100;

            foreach (KeyValuePair<Type, decimal> mineralPair in pair.Value.First.RefineOutputList)
            {
                total_revenue += priceList.PriceList[mineralPair.Key] * portionAmount;
            }

            pair.Value.Second -= portionAmount * 100;
        }

        return new SaleReport(total_revenue * (1 - TaxRate), total_revenue, total_revenue * TaxRate);
    }
}