using Itmo.ObjectOrientedProgramming.Lab1.Models.Ores;
using Xunit;

namespace Itmo.ObjectOrientedProgramming.Lab1.Tests;

/// <summary>
/// Пример юнит тестов реализующих успешные сценарии
/// </summary>
public class OreTests
{
    [Fact]
    public void Kernite_Instance_CanBeCreated()
    {
        // Arrange:
        const string expectedToStringResult = "Kernite { RefineOutputList = System.Collections.Generic.Dictionary`2[Itmo.ObjectOrientedProgramming.Lab1.Utils.TypedValue`1[Itmo.ObjectOrientedProgramming.Lab1.Mineral],System.Int32], VolumePerUnit = VolumeValue { Value = 1,2 } }";

        // Act:
        var kernite = new Kernite();

        // ToString у Record'ов возвращает строку вида
        // <record type name> { <property name> = <value>, <property name> = <value>, ...}
        string actualToStringResult = kernite.ToString();

        // Assert:
        Assert.Equal(expectedToStringResult, actualToStringResult);
    }

    [Fact]
    public void Isogen_Instance_CanBeCreated()
    {
        // Arrange:
        const string expectedToStringResult = "Pyroxeres { RefineOutputList = System.Collections.Generic.Dictionary`2[Itmo.ObjectOrientedProgramming.Lab1.Utils.TypedValue`1[Itmo.ObjectOrientedProgramming.Lab1.Mineral],System.Int32], VolumePerUnit = VolumeValue { Value = 0,3 } }";

        // Act:
        var isogen = new Pyroxeres();

        string actualToStringResult = isogen.ToString();

        // Assert:
        Assert.Equal(expectedToStringResult, actualToStringResult);
    }

    [Fact]
    public void Scordite_Instance_CanBeCreated()
    {
        // Arrange:
        const string expectedToStringResult = "Scordite { RefineOutputList = System.Collections.Generic.Dictionary`2[Itmo.ObjectOrientedProgramming.Lab1.Utils.TypedValue`1[Itmo.ObjectOrientedProgramming.Lab1.Mineral],System.Int32], VolumePerUnit = VolumeValue { Value = 0,15 } }";

        // Act:
        var scordite = new Scordite();

        string actualToStringResult = scordite.ToString();

        // Assert:
        Assert.Equal(expectedToStringResult, actualToStringResult);
    }

    [Fact]
    public void Veldspar_Instance_CanBeCreated()
    {
        // Arrange:
        const string expectedToStringResult = "Veldspar { RefineOutputList = System.Collections.Generic.Dictionary`2[Itmo.ObjectOrientedProgramming.Lab1.Utils.TypedValue`1[Itmo.ObjectOrientedProgramming.Lab1.Mineral],System.Int32], VolumePerUnit = VolumeValue { Value = 0,1 } }";

        // Act:
        var veldspar = new Veldspar();

        string actualToStringResult = veldspar.ToString();

        // Assert:
        Assert.Equal(expectedToStringResult, actualToStringResult);
    }
}