using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSlots : UIBase
{
    // 칸은 미리 다 있어야하고
    // 빈칸은 null로 두고
    ItemSlot[] _items = new ItemSlot[6];

    public override void Init()
    {
        GenerateSlots();
    }

    void GenerateSlots()
    {
        GameObject slotOriginal = Resources.Load<GameObject>("Prefabs/UI/PlayerStatusUI/ItemSlot");
        for (int i = 0; i < _items.Length; i++)
        {
            GameObject slotInstance = Instantiate<GameObject>(slotOriginal, transform);
            ItemSlot itemSlot = slotInstance.GetComponent<ItemSlot>();
            itemSlot.Init();

            _items[i] = itemSlot;
        }
    }

    public void AddItem(string imagePath)
    {
        for (int i = 0; i < _items.Length; i++)
        {
            if (_items[i].isFilled == false)
            {
                _items[i].SetItem(imagePath);
                break;
            }
        }
    }
}
