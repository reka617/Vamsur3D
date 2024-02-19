using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterInfoMenu : MonoBehaviour
{
    [SerializeField] TMP_Text _heroName;   
    [SerializeField] TMP_Text _weaponName;
    [SerializeField] Image _heroPortrait;
    [SerializeField] Image _weaponPortrait;
    Define.HeroType _hType;
    Define.WeaponType _wType;

    public void SetData(Define.HeroType hType, Define.WeaponType wType)
    {
        _hType = hType;
        _wType = wType;
        Define.Hero heroData = GenericSingleton<DataManager>.getInstance().GetHeroInfo(_hType);
        Define.Weapon weaponData = GenericSingleton<DataManager>.getInstance().GetWeaponInfo(_wType);

        Sprite hThumb = Instantiate(Resources.Load<Sprite>(heroData.thumbnailPath));
        Sprite wThumb = Instantiate(Resources.Load<Sprite>(weaponData.thumbnailPath));
        _heroName.text = _hType.ToString();
        _heroPortrait.sprite = hThumb;
        _weaponName.text = _wType.ToString();
        _weaponPortrait.sprite = wThumb;
    }
}

