namespace Itmo.ObjectOrientedProgramming.Lab1.Utils;

public record TypeDescendant<TBase>
{
    public Type Type { get; }

    public TypeDescendant(Type specifiedType)
    {
        if (!specifiedType.IsAssignableTo(typeof(TBase)))
            throw new ArgumentException("Type is not descendant");

        Type = specifiedType;
    }
}