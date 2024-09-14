public class GoldClass
{
    private int gold;

    public int Gold { get { return gold; } set {  gold = value; } }
    public void AddGold(int amount)
    {
        gold += amount;
    }
}
