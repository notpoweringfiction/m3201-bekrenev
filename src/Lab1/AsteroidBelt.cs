namespace Itmo.ObjectOrientedProgramming.Lab1;

public class AsteroidBelt
{
    public string Name { get; init; }

    public int Distance { get; init; }

    public Type BeltOreType { get; init; }

    public Ore BeltOre { get; init; }

    public AsteroidBelt(string name, int dist, Type oreType, Ore ore)
    {
        if (dist < 0)
        {
            throw new ArgumentException("Negative distance to ore belt");
        }

        if (!oreType.IsAssignableTo(typeof(Ore)))
        {
            throw new ArgumentException("Invalid ore belt type");
        }

        Name = name;
        Distance = dist;
        BeltOreType = oreType;
        BeltOre = ore;
    }
}