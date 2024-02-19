using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class CharacterBoxController : MonoBehaviour
{
    //전체리스트에 집어넣고 지금의 게임오브젝트 클릭하면 전체끄고 지금 게임오브젝트만 실행

    //이전오브젝트정보를 받아와서 지금 현재 오브젝트가 실행될 경우 이전오브젝트의 setactive(false)
    [SerializeField] MenuUIController _menuUIController;
    Transform cBeforeBoxInfo = null;
    GameObject childObject;
    Define.HeroType _curSelectHeroType;
    Define.WeaponType _curSelectHeroWeaponType;



    public void SetData(Define.HeroType hType, Define.WeaponType wType)
    {
        _curSelectHeroType = hType;
        _curSelectHeroWeaponType = wType;
    }
    public void isBeforeBoxInfo(SelectedInfoBox ib)
    {
        if (cBeforeBoxInfo == null)
        {
            cBeforeBoxInfo = ib.SelectBackground;
            return;
        }
        cBeforeBoxInfo.gameObject.SetActive(false);
        cBeforeBoxInfo = ib.SelectBackground;
    }



    public void getMenuUIControllerData()
    {
        _menuUIController.OpenSelectCharacterPanel(_curSelectHeroType, _curSelectHeroWeaponType);
    }

    public void OnReturnMainMenuButtonFromCharacterInfoMenu()
    {
        childObject = transform.Find("CharacterInfoMenu").gameObject;
        childObject.SetActive(false);
        gameObject.SetActive(false);
    }


} 
