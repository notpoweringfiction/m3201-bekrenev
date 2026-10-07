using Itmo.ObjectOrientedProgramming.Lab1.Utils;

namespace Itmo.ObjectOrientedProgramming.Lab1;

public class AsteroidBelt
{
    public string Name { get; init; }

    public DistanceValue Distance { get; init; }

    public Ore BeltOre { get; init; }

    public AsteroidBelt(string name, DistanceValue dist, Ore ore)
    {
        Name = name;
        Distance = dist;
        BeltOre = ore;
    }
}