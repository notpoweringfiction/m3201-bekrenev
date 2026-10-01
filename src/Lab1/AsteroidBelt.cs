namespace Itmo.ObjectOrientedProgramming.Lab1;

public class AsteroidBelt
{
    public string Name { get; }

    public int Distance { get; }

    public Ore BeltOre { get; }

    public AsteroidBelt(string name, int dist, Ore ore)
    {
        Name = name;
        Distance = dist;
        BeltOre = ore;
    }
}