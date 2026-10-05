using Itmo.ObjectOrientedProgramming.Lab1.Models.Minerals;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Ores;
using Itmo.ObjectOrientedProgramming.Lab1.Models.Strategies;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

// Тестовые сценарии из задания (раздел «Тестовые сценарии»).
// Значения по умолчанию: флот – один Venture, стратегия «Общий трюм»;
// пояс «Пояс A» – 4 а.е., Veldspar; налог 0;
// прайс-лист – Tritanium 4, Pyerite 10, Mexallon 70, Isogen 150.
public class ContractScenarioTests
{
    private readonly MineralPriceData _defaultPriceList = new MineralPriceData(new Dictionary<Type, int>
    {
        [typeof(Tritanium)] = 4,
        [typeof(Pyerite)] = 10,
        [typeof(Mexallon)] = 70,
        [typeof(Isogen)] = 150,
    });

    private readonly Strategy _defaultStrategy;

    private readonly AsteroidBelt _defaultBelt;

    private readonly Fleet _defaultFleet;

    private readonly Station _defaultStation;

    private readonly Calculator calculator;

    private void CompareContractSuccessResults(Calculator.MappedContractResults expectedResults, Calculator.MappedContractResults actualResults)
    {
        Assert.Equal(
            expectedResults.WorkTime,
            actualResults.WorkTime);
        Assert.Equal(
            expectedResults.HarvestCyclesAmount,
            actualResults.HarvestCyclesAmount);
        Assert.Equal(
            expectedResults.TotalHarvestedVolume,
            actualResults.TotalHarvestedVolume);
        Assert.Equal(
            expectedResults.SoldMinerals,
            actualResults.SoldMinerals);
        Assert.Equal(
            expectedResults.StoragedOre,
            actualResults.StoragedOre);
        Assert.Equal(
            expectedResults.TotalRevenue,
            actualResults.TotalRevenue);
        Assert.Equal(
            expectedResults.TotalRent,
            actualResults.TotalRent);
        Assert.Equal(
            expectedResults.TaxesAmount,
            actualResults.TaxesAmount);
        Assert.Equal(
            expectedResults.NetProfit,
            actualResults.NetProfit);
    }

    public ContractScenarioTests()
    {
        _defaultStrategy = new SharedStrat();

        _defaultBelt = new AsteroidBelt("Пояс A", 4, typeof(Veldspar), new Veldspar());

        _defaultFleet = new Fleet(new List<Ship> { new Venture() }, _defaultStrategy);

        _defaultStation = new Station(0);

        calculator = new Calculator();
    }

    [Fact(DisplayName = "Сценарий 1. Контракт на срок")]
    public void TimeContract_WithSingleVenture_IsCompleted()
    {
        // Arrange: контракт на 6 ч
        var contract = new Models.Contracts.TimeContract(
            selectedBelt: _defaultBelt,
            selectedFleet: _defaultFleet,
            givenPriceList: _defaultPriceList,
            contractStation: _defaultStation,
            contractTime: 6);

        // Act
        Calculator.CalculationResult result = calculator.Calculate(contract);

        _defaultStation.ClearStorage();

        // Assert: выполнен; 1 рейс, время работы 6 ч, добыто 400 м³;
        // Tritanium – 8000; выручка 32 000, аренда 6000, прибыль 26 000
        Assert.IsType<Calculator.CalculationSuccess>(result);
        Assert.IsType<Calculator.MappedContractResults>(((Calculator.CalculationSuccess)result).Results);

        Calculator.MappedContractResults actualResults = ((Calculator.CalculationSuccess)result).Results;

        var expectedResults =
            new Calculator.MappedContractResults(
                WorkTime: 6,
                HarvestCyclesAmount: 1,
                TotalHarvestedVolume: 400,
                SoldMinerals: new Dictionary<Type, int>
                    { [typeof(Tritanium)] = 8000 },
                StoragedOre: new Dictionary<Type, int>
                {
                    [typeof(Veldspar)] = 0,
                },
                TotalRevenue: 32000,
                TotalRent: 6000,
                TaxesAmount: 0,
                NetProfit: 26000);

        CompareContractSuccessResults(expectedResults, actualResults);
    }

    [Fact(DisplayName = "Сценарий 2. Пустой флот")]
    public void Fleet_WithoutShips_CannotBeCreated()
    {
        // Arrange + Act: создание флота без кораблей

        // Assert: исключение
        Assert.Throws<ArgumentException>(() => new Fleet(new List<Ship>(), _defaultStrategy));
    }

    [Fact(DisplayName = "Сценарий 3. Контракт на объём")]
    public void VolumeContract_WithSingleVenture_IsCompleted()
    {
        // Arrange: контракт на 1000 м³
        var contract = new Models.Contracts.VolumeContract(
            selectedBelt: _defaultBelt,
            selectedFleet: _defaultFleet,
            givenPriceList: _defaultPriceList,
            contractStation: _defaultStation,
            contractVolume: 1000);

        // Act
        Calculator.CalculationResult result = calculator.Calculate(contract);

        _defaultStation.ClearStorage();

        // Assert: выполнен; 3 рейса (400, 400, 200 м³), время работы 16 ч;
        // Tritanium – 20 000; выручка 80 000, аренда 16 000, прибыль 64 000
        Assert.IsType<Calculator.CalculationSuccess>(result);
        Assert.IsType<Calculator.MappedContractResults>(((Calculator.CalculationSuccess)result).Results);

        Calculator.MappedContractResults actualResults = ((Calculator.CalculationSuccess)result).Results;

        var expectedResults =
            new Calculator.MappedContractResults(
                WorkTime: 16,
                HarvestCyclesAmount: 3,
                TotalHarvestedVolume: 1000,
                SoldMinerals: new Dictionary<Type, int>
                    { [typeof(Tritanium)] = 20_000 },
                StoragedOre: new Dictionary<Type, int>
                {
                    [typeof(Veldspar)] = 0,
                },
                TotalRevenue: 80_000,
                TotalRent: 16_000,
                TaxesAmount: 0,
                NetProfit: 64_000);

        CompareContractSuccessResults(expectedResults, actualResults);
    }

    [Fact(DisplayName = "Сценарий 4. Отклонение по сроку")]
    public void TimeContract_TooShort_IsRejected()
    {
        // Arrange: контракт на 2 ч
        var contract = new Models.Contracts.TimeContract(
            selectedBelt: _defaultBelt,
            selectedFleet: _defaultFleet,
            givenPriceList: _defaultPriceList,
            contractStation: _defaultStation,
            contractTime: 2);

        // Act
        Calculator.CalculationResult result = calculator.Calculate(contract);

        // Assert: отклонён – срока не хватает на один рейс
        Assert.IsType<Calculator.CalculationFailure>(result);
        Assert.IsType<TimeContractError>(((Calculator.CalculationFailure)result).Error);
    }

    [Fact(DisplayName = "Сценарий 5. Отклонение по прайс-листу")]
    public void Contract_WithIncompletePriceList_IsRejected()
    {
        // Arrange: пояс с Scordite, в прайс-листе нет цены Pyerite; контракт на 6 ч
        var contract = new Models.Contracts.TimeContract(
            selectedBelt: new AsteroidBelt("Пояс B", 1, typeof(Scordite), new Scordite()),
            selectedFleet: _defaultFleet,
            givenPriceList: new MineralPriceData(new Dictionary<Type, int>
                {
                    [typeof(Tritanium)] = 4,
                    [typeof(Mexallon)] = 70,
                    [typeof(Isogen)] = 150,
                }),
            contractStation: _defaultStation,
            contractTime: 6);

        // Act
        Calculator.CalculationResult result = calculator.Calculate(contract);

        // Assert: отклонён – в прайс-листе нет цены минерала из выхода руды
        Assert.IsType<Calculator.CalculationFailure>(result);
        Assert.IsType<PriceListError>(((Calculator.CalculationFailure)result).Error);
    }

    [Fact(DisplayName = "Сценарий 6. Ставка вне [0,1]")]
    public void Contract_WithOutOfBoundsTaxRate_CannotBeCreated()
    {
        // Arrange + Act: налог на станции вне [0,1]

        // Assert: исключение
        Assert.Throws<ArgumentException>(() => new Station(taxRate: 4));
    }
}