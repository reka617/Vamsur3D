using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBoxController : MonoBehaviour
{
    [SerializeField] MenuUIController _menuUIController;
    GameObject childObject;
    Transform wBeforeBoxInfo = null;
    Define.WeaponType _curSelectWeaponType;

    public void SetData(Define.WeaponType type)
    {
        _curSelectWeaponType = type;
    }

    public void isBeforeBoxInfo(SelectedInfoBox ib)
    {
        if (wBeforeBoxInfo == null)
        {
            wBeforeBoxInfo = ib.SelectBackground;
            return;
        }
        wBeforeBoxInfo.gameObject.SetActive(false);
        wBeforeBoxInfo = ib.SelectBackground;
    }
    public void getMenuUIControllerData()
    {
        _menuUIController.OpenSelectWeaponPanel(_curSelectWeaponType);  
    }

    public void OnReturnMainMenuButtonFromWeaponInfoMenu()
    {
        childObject = transform.Find("WeaponInfoMenu").gameObject;
        
        SelectedInfoBox[] boxes = GetComponentsInChildren<SelectedInfoBox>();
        foreach(SelectedInfoBox box in boxes)
        {
            Destroy(box.gameObject);
        }

        childObject.SetActive(false);
        gameObject.SetActive(false);
    }
}
