public class ShopShoes : IItemSetter
{
    protected float _intervalTime;

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
        return EquipmentType.Shoes;
    }
}
public class ShopShoes_A : AbstractOxygenTank
{
    public ShopShoes_A()
    {
        _intervalTime = 1f;
    }
}
public class ShopShoes_B : AbstractOxygenTank
{
    public ShopShoes_B()
    {
        _intervalTime = 3f;
    }
}

//public abstract class AbstractShoes : ICharacterBaseStatus
//{
//    protected float oxygenDecreaseInterval = 1f;
//    public abstract void InitializeInterval();
//    public void ApplyEffect(float effectValue)
//    {
//        oxygenDecreaseInterval += effectValue;
//    }

//    public void RemoveEffect(float effectValue)
//    {
//        oxygenDecreaseInterval -= effectValue;
//    }
//}