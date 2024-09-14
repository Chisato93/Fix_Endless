using UnityEngine;

public interface IItemSetter
{
    void SetItem(ICharacterBaseStatus characterStat);
    void RemoveItem(ICharacterBaseStatus characterStat);
    EquipmentType GetSlotType();
}
