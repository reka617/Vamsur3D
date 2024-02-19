using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemSlot : MonoBehaviour
{
    public bool isFilled = false;

    private Image _itemImage;
    
    public void Init()
    {
        _itemImage = transform.Find("Item").GetComponent<Image>();
    }

    public void SetItem(string imagePath)
    {
        isFilled = true;
        Sprite sprite = Resources.Load<Sprite>(imagePath);
        _itemImage.sprite = sprite;
    }

    void Start()
    {
        Init();
    }
}
