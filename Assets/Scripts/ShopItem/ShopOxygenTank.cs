public abstract class AbstractOxygenTank : IItemSetter
{
    protected float _intervalTime;
    public int price;

    public void SetItem(ICharacterBaseStatus characterStat)
    {
        characterStat.ApplyEffect(_intervalTime);
    }

    public void RemoveItem(ICharacterBaseStatus characterStat)
    {
        characterStat.RemoveEffect(_intervalTime);
    }

    public EquipmentType GetSlotType()
    {
        return EquipmentType.OxygenTank;
    }
}
public class AbstractOxygenTank_A : AbstractOxygenTank
{
    public AbstractOxygenTank_A()
    {
        _intervalTime = 1f;
        price = 100;
    }
}public class AbstractOxygenTank_B : AbstractOxygenTank
{
    public AbstractOxygenTank_B()
    {
        _intervalTime = 3f;
        price = 500;
    }
}