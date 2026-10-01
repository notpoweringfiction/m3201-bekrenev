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

    protected override void UpdateStateBeforeHarvest()
    {
        TotalWorkTime += TimeToField;
    }

    protected override void UpdateStateAfterHarvest(int cycleHarvest)
    {
        if (cycleHarvest > 0) TotalWorkTime++;
        TotalWorkTime += TimeToField;
    }

    protected override bool CanStartVoyage()
    {
        return HarvestedVolume > ContractVolume;
    }
}