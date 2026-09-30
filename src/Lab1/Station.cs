using OreDataPack = Itmo.ObjectOrientedProgramming.Lab1.PairDataPack<Itmo.ObjectOrientedProgramming.Lab1.IOre, int>;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Station
{
    private decimal TaxRate { get; init; }

    private Dictionary<Type, int> MineralStorage { get; } = new Dictionary<Type, int>();

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
    }

    public void ProcessOres(OreDataPack oreInput)
    {
        foreach (KeyValuePair<Type, int> mineralPair in oreInput.First.RefineOutputList)
        {
            int totalMineralAmount = mineralPair.Value * oreInput.Second;
            MineralStorage.TryAdd(mineralPair.Key, 0);
            MineralStorage[mineralPair.Key] += totalMineralAmount;
        }
    }

    public SaleReport SellMinerals(MineralPriceData priceList)
    {
        int total_revenue = 0;

        foreach (KeyValuePair<Type, int> pair in MineralStorage)
        {
            int portionAmount = pair.Value / 100;
            MineralStorage[pair.Key] -= portionAmount * 100;
            total_revenue += priceList.PriceList[pair.Key] * portionAmount;
        }

        return new SaleReport(total_revenue * (1 - TaxRate), total_revenue, total_revenue * TaxRate);
    }
}