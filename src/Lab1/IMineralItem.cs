namespace Itmo.ObjectOrientedProgramming.Lab1;

public class IMineralItem
{
    public int Quantity { get; set; }

    protected IMineralItem(int startQty = 0)
    {
        Quantity = startQty;
    }
}