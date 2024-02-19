using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WeaponInfoMenu : MonoBehaviour
{
    [SerializeField] Image _thumbImage;
    [SerializeField] TMP_Text _nameText;
    [SerializeField] TMP_Text _lvText;
    [SerializeField] TMP_Text _costText;
    [SerializeField] TMP_Text _totalGoldText;
    [SerializeField] Button _button;
    
    Define.WeaponType _type;

    public void SetData(Define.WeaponType type)
    {
        _type = type;

        Define.Weapon weaponData = GenericSingleton<DataManager>.getInstance().GetWeaponInfo(_type);
        int curEnhanceLevel = GenericSingleton<DataManager>.getInstance().GetWeaponEnhanceLevel(_type);
        Define.WeaponEnhanceData enhanceData = GenericSingleton<DataManager>.getInstance().GetWeaponEnhanceInfo(_type, curEnhanceLevel);

        Sprite thumb = Instantiate(Resources.Load<Sprite>(weaponData.thumbnailPath));
        _thumbImage.sprite = thumb;
        _nameText.text = _type.ToString();
        _lvText.text = curEnhanceLevel.ToString();
        _costText.text = enhanceData.cost.ToString();
        _totalGoldText.text = GenericSingleton<GameManager>.getInstance().TotalGold.ToString();
    }
    public void EnhanceWeapon()
    {
        bool result = GenericSingleton<GameManager>.getInstance().UpgradeWeaponEnhanceLevel(_type);

        if (result == true)
        {
            int curEnhanceLevel = GenericSingleton<DataManager>.getInstance().GetWeaponEnhanceLevel(_type);
            _lvText.text = curEnhanceLevel.ToString();
        }

        Debug.Log($"강화 성공 여부: {result} {_type}강화 레벨: {GenericSingleton<DataManager>.getInstance().GetWeaponEnhanceLevel(_type)}");
        Debug.Log(GenericSingleton<GameManager>.getInstance().TotalGold);
    }
}
