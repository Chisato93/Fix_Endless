using System.Collections.Generic;
using UnityEngine;

public class ItemManager
{
    private Dictionary<EquipmentType, IItemSetter> _equippedItems = new Dictionary<EquipmentType, IItemSetter>();

    public void EquipItem(ICharacterBaseStatus characterStat, IItemSetter newItem)
    {
        EquipmentType equpmentType = newItem.GetSlotType();

        // 현재 장착된 아이템 해제
        if (_equippedItems.ContainsKey(equpmentType))
        {
            _equippedItems[equpmentType].RemoveItem(characterStat);
        }

        // 새 아이템 장착
        newItem.SetItem(characterStat);
        _equippedItems[equpmentType] = newItem;
    }
    public void UnequipItem(EquipmentType equipmnetType, ICharacterBaseStatus characterStat)
    {
        if (_equippedItems.ContainsKey(equipmnetType))
        {
            _equippedItems[equipmnetType].RemoveItem(characterStat);
            _equippedItems.Remove(equipmnetType);
        }
    }
    public IItemSetter GetEquippedItem(EquipmentType equipmnetType)
    {
        return _equippedItems.ContainsKey(equipmnetType) ? _equippedItems[equipmnetType] : null;
    }
}
