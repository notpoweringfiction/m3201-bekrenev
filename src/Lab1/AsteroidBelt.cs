namespace Itmo.ObjectOrientedProgramming.Lab1;

public class AsteroidBelt
{
    public string Name { get; }

    public int Distance { get; }

    public IOreItem BeltOre { get; }

    public AsteroidBelt(string name, int dist, IOreItem ore)
    {
        Name = name;
        Distance = dist;
        BeltOre = ore;
    }
}