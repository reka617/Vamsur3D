using System.Collections.Generic;
using UnityEngine;
public class WeaponData : MonoBehaviour
{
    [SerializeField] GameObject _item;
    [SerializeField] Transform _contentTransform;
    List<GameObject> lstItems = new List<GameObject>();
    public void StartPanel()//매개변수 획득아이템
    {
        _item.SetActive(true);
        for (int i = 1; i < 7; i++) //(int)EItem.max 를 아이템 획득 숫자로 변경
                                                 //   foreach (ItemData data in _itemcsvcon.lstItemDates)
        {
            GameObject temp = Instantiate(_item, _contentTransform);
            temp.GetComponent<LastSceneItem>().init();
            lstItems.Add(temp);
            Debug.Log("Startpanul");
        }
    }
}
