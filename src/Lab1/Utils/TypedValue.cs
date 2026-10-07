namespace Itmo.ObjectOrientedProgramming.Lab1.Utils;

public class TypedValue<T> where T : notnull
{
    public Type ValueType { get; }

    public T Instance { get; }

    public TypedValue(T instance)
    {
        ValueType = instance.GetType();
        Instance = instance;
    }

    public override int GetHashCode()
    {
        return ValueType.GetHashCode();
    }

    public override bool Equals(object? obj)
    {
        return obj is TypedValue<T> other && ValueType == other.ValueType;
    }
}
