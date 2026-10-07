using Itmo.ObjectOrientedProgramming.Lab1.Models.Minerals;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

/// <summary>
/// Пример юнит тестов реализующих успешные сценарии
/// </summary>
public class MineralTests
{
    [Fact]
    public void Tritanium_Instance_CanBeCreated()
    {
        // Arrange:
        const string expectedToStringResult = "Tritanium { }";

        // Act:
        var tritanium = new Tritanium();

        // ToString у Record'ов возвращает строку вида
        // <record type name> { <property name> = <value>, <property name> = <value>, ...}
        string actualToStringResult = tritanium.ToString();

        // Assert:
        Assert.Equal(expectedToStringResult, actualToStringResult);
    }

    [Fact]
    public void Isogen_Instance_CanBeCreated()
    {
        // Arrange:
        const string expectedToStringResult = "Isogen { }";

        // Act:
        var isogen = new Isogen();

        string actualToStringResult = isogen.ToString();

        // Assert:
        Assert.Equal(expectedToStringResult, actualToStringResult);
    }

    [Fact]
    public void Mexallon_Instance_CanBeCreated()
    {
        // Arrange:
        const string expectedToStringResult = "Mexallon { }";

        // Act:
        var mexallon = new Mexallon();

        string actualToStringResult = mexallon.ToString();

        // Assert:
        Assert.Equal(expectedToStringResult, actualToStringResult);
    }

    [Fact]
    public void Pyerite_Instance_CanBeCreated()
    {
        // Arrange:
        const string expectedToStringResult = "Pyerite { }";

        // Act:
        var pyerite = new Pyerite();

        string actualToStringResult = pyerite.ToString();

        // Assert:
        Assert.Equal(expectedToStringResult, actualToStringResult);
    }
}