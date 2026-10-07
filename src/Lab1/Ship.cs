namespace Itmo.ObjectOrientedProgramming.Lab1;

public class Ship
{
    public CargoModule CargoHold { get; init; }

    public ShipModel Model { get; init; }

    public Ship(ShipModel shipModel)
    {
        CargoHold = new CargoModule(shipModel.MaxCargoVolume);
        Model = shipModel;
    }
}