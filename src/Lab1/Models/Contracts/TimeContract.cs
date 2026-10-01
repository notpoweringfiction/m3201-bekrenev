namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Contracts;

public class TimeContract : Contract
{
    public int ContractTime { get; init; }

    public TimeContract(AsteroidBelt selectedBelt, Fleet selectedFleet, MineralPriceData givenPriceList, Station contractStation, int contractTime)
        : base(selectedBelt, selectedFleet, givenPriceList, contractStation)
    {
        ContractTime = contractTime;

        ValidationInfo valid = ValidateContract();

        ValidationStatus = ValidationStatus.Success ? valid : ValidationStatus;
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
        return TotalWorkTime + (2 * TimeToField) + 1 <= ContractTime;
    }

    private ValidationInfo ValidateContract()
    {
        return (TimeToField * 2) + 2 <= ContractTime
        ?
            new ValidationInfo(
                Success: true,
                ErrorMessage: null)
        :
            new ValidationInfo(
                Success: false,
                ErrorMessage: "Contract time too short");
    }
}