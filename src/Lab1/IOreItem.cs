namespace Itmo.ObjectOrientedProgramming.Lab1;

public class IOreItem
{
    public IReadOnlyCollection<IMineralItem> RefineOutputList { get; }

    public decimal Volume { get; }

    public decimal VolumePerUnit { get; }

    protected IOreItem(decimal volume, decimal volumePerUnit, IReadOnlyCollection<IMineralItem> refinementMineralsList)
    {
        Volume = volume;
        VolumePerUnit = volumePerUnit;
        RefineOutputList = refinementMineralsList;
    }
}