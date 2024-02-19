using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class WeaponSelectItemUI : MonoBehaviour
{
    public Define.Weapon weaponInfo;

    Image _itemImage;
    TMP_Text _itemName;
    TMP_Text _itemRank;
    TMP_Text _itemDesc;
    TMP_Text _nextLevelText;
    TMP_Text _levelOptionText;

    Button _button;

    public void Init(Define.Weapon weaponInfo)
    {
        this.weaponInfo = weaponInfo;
        _itemImage = transform.Find("ItemImageFrame/ItemImage").GetComponent<Image>();
        _itemName = transform.Find("ItemNameText").GetComponent<TMP_Text>();
        _itemRank = transform.Find("ItemRankText").GetComponent<TMP_Text>();
        _itemDesc = transform.Find("ItemDescText").GetComponent<TMP_Text>();
        _nextLevelText = transform.Find("NextLevelText").GetComponent<TMP_Text>();
        _levelOptionText = transform.Find("LevelOptionText").GetComponent<TMP_Text>();

        _button = GetComponent<Button>();

        string imageUrl = weaponInfo.thumbnailPath;
        string name = ((Define.WeaponType) weaponInfo.id).ToString();
        string rank = weaponInfo.rank;
        string desc = weaponInfo.desc;
        int nextLevel = weaponInfo.lv;
        string nextLevelOption = weaponInfo.levelDesc;

        SetData(imageUrl, name, rank, desc, nextLevel, nextLevelOption);

        UnityAction action = () =>
        {
            Debug.Log($"{(Define.WeaponType)weaponInfo.id} {weaponInfo.lv}");
            GenericSingleton<GameManager>.getInstance().SetCurrentWeaponLevel((Define.WeaponType)weaponInfo.id, weaponInfo.lv);
            GenericSingleton<GameManager>.getInstance().Player.GetComponent<WeaponController>().LoadWeapon(weaponInfo);
            GenericSingleton<UIManager>.getInstance().GetUI<WeaponSelectUI>().Close();
        };

        SetClickEvent(action);
    }

    void SetData(string imageUrl, string itemName, string itemRank, string itemDesc, int nextLevel, string nextlevelOption)
    {
        // 이미지
        _itemImage.sprite = Resources.Load<Sprite>(imageUrl);
        // 이름
        _itemName.text = itemName;
        // 등급
        _itemRank.text = itemRank;
        // 설명
        _itemDesc.text = itemDesc;
        // 레벨
        _nextLevelText.text = "Level " + nextLevel.ToString();
        // 레벨 옵션
        _levelOptionText.text = nextlevelOption;
    }

    void SetClickEvent(UnityAction action)
    {
        _button.onClick.AddListener(action);
    }
}
