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
                Error: new UnknownError("Unknown error")),
        };
    }

    protected override void UpdateStateBeforeVoyage()
    {
        TotalWorkTime += TimeToField;
        Console.WriteLine("Flew to the field, total: " + TotalWorkTime.ToString());
    }

    protected override void UpdateStateAfterHarvestCycle(int cycleHarvest)
    {
    }

    protected override void UpdateStateAfterVoyage(int voyageHarvest)
    {
        if (voyageHarvest > 0)
        {
            ++TotalWorkTime;
            Console.WriteLine("worked, total " + TotalWorkTime.ToString());
        }

        TotalWorkTime += TimeToField;
        Console.WriteLine("Flew from the field, total: " + TotalWorkTime.ToString());
    }

    protected override bool CanStartVoyage()
    {
        return TotalWorkTime + (2 * TimeToField) + 1 <= ContractTime;
    }

    protected override bool CanStartHarvestCycle()
    {
        return TotalWorkTime + TimeToField + 1 <= ContractTime;
    }

    private ValidationInfo ValidateContract()
    {
        return (TimeToField * 2) + 2 <= ContractTime
        ?
            new ValidationInfo.ContractValid()
        :
            new ValidationInfo.ContractInvalid(
                Error: new TimeContractError("Contract time too short"));
    }
}