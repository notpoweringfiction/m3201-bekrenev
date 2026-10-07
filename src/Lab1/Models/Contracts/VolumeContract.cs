namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Contracts;

public class VolumeContract : Contract
{
    public int ContractVolume { get; init; }

    public int HarvestedVolume { get; private set; }

    public VolumeContract(AsteroidBelt selectedBelt, Fleet selectedFleet, MineralPriceData givenPriceList, Station contractStation, int contractVolume)
        : base(selectedBelt, selectedFleet, givenPriceList, contractStation)
    {
        ContractVolume = contractVolume;
    }

    protected override void UpdateStateBeforeVoyage()
    {
        TotalWorkTime += TimeToField;
    }

    protected override void UpdateStateAfterHarvestCycle(int cycleHarvest)
    {
        HarvestedVolume += cycleHarvest;
    }

    protected override void UpdateStateAfterVoyage(int voyageHarvest)
    {
        if (voyageHarvest > 0)
        {
            ++TotalWorkTime;
        }

        TotalWorkTime += TimeToField;
    }

    protected override bool CanStartVoyage()
    {
        return HarvestedVolume < ContractVolume;
    }

    protected override bool CanStartHarvestCycle()
    {
        return HarvestedVolume < ContractVolume;
    }
}