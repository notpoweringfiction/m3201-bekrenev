namespace Itmo.ObjectOrientedProgramming.Lab1.Models.Contracts;

public class TimeContract : Contract
{
    public int ContractTime { get; init; }

    public TimeContract(AsteroidBelt selectedBelt, Fleet selectedFleet, MineralPriceData givenPriceList, Station contractStation, int contractTime)
        : base(selectedBelt, selectedFleet, givenPriceList, contractStation)
    {
        ContractTime = contractTime;

        ValidationInfo validation = ValidateContract();

        ValidationStatus = ValidationStatus switch
        {
            ValidationInfo.ContractValid valid => validation,
            ValidationInfo.ContractInvalid invalid => invalid,
            _ => new ValidationInfo.ContractInvalid(
                ErrorMessage: "Unknown error"),
        };
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
            new ValidationInfo.ContractValid()
        :
            new ValidationInfo.ContractInvalid(
                ErrorMessage: "Contract time too short");
    }
}