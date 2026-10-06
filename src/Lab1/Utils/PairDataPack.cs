namespace Itmo.ObjectOrientedProgramming.Lab1;

public class PairDataPack<TFirst, TSecond>
{
    public TFirst First { get; }

    public TSecond Second { get; }

    public PairDataPack(TFirst newFirst, TSecond newSecond)
    {
        First = newFirst;
        Second = newSecond;
    }
}