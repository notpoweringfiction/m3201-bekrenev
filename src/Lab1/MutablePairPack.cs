namespace Itmo.ObjectOrientedProgramming.Lab1;

public class MutablePairPack<TFirst, TSecond>
{
    public TFirst First { get; set; }

    public TSecond Second { get; set; }

    public MutablePairPack(TFirst newFirst, TSecond newSecond)
    {
        First = newFirst;
        Second = newSecond;
    }
}