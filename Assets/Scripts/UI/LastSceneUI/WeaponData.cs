using System.Collections.Generic;
using UnityEngine;
public class WeaponData : MonoBehaviour
{
    [SerializeField] GameObject _item;
    [SerializeField] Transform _contentTransform;
    List<GameObject> lstItems = new List<GameObject>();
    public void StartPanel()//�Ű����� ȹ�������
    {
        _item.SetActive(true);
        for (int i = 1; i < 7; i++) //(int)EItem.max �� ������ ȹ�� ���ڷ� ����
                                                 //   foreach (ItemData data in _itemcsvcon.lstItemDates)
        {
            GameObject temp = Instantiate(_item, _contentTransform);
            temp.GetComponent<LastSceneItem>().init();
            lstItems.Add(temp);
            Debug.Log("Startpanul");
        }
    }
}
