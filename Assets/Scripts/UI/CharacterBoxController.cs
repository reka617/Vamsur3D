using System.Collections;
using System.Collections.Generic;
using System.Net;
using UnityEngine;

public class CharacterBoxController : MonoBehaviour
{
    //��ü����Ʈ�� ����ְ� ������ ���ӿ�����Ʈ Ŭ���ϸ� ��ü���� ���� ���ӿ�����Ʈ�� ����

    //����������Ʈ������ �޾ƿͼ� ���� ���� ������Ʈ�� ����� ��� ����������Ʈ�� setactive(false)
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
