using Define;
using DG.Tweening;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SelectedInfoBox : MonoBehaviour
{
    [SerializeField] TMP_Text _nameText;
    [SerializeField] Image _thumb;
    CharacterBoxController cb;
    WeaponBoxController wb;
    Transform hoveringCharacterBox;
    Transform selectedBackground;
    HeroType myType;
    public Transform SelectBackground { get { return selectedBackground; } }

    Vector3 Maxv3 = new Vector3(1.05f, 1.05f, 1.05f);
    Vector3 Minv3 = Vector3.one;
    string _thumbPath;
    string _name;

    public void Init(CharacterBoxController cbc)
    {
        cb = cbc;
    }

    public void Init(WeaponBoxController wbc)
    {
        wb = wbc;
    }

    public void SetData(string thumbPath, string name, HeroType hType = HeroType.None)
    {
        _thumbPath = thumbPath;
        myType = hType;
        _name = name;
    }

    void Start()
    {
        if (_thumbPath == null || _name == null)
            return;

        _nameText.text = _name;
        _thumb.sprite = Instantiate(Resources.Load<Sprite>(_thumbPath));
        _thumb.color = Color.white;
    }

    public void OnClickedCharacterBox()
    {
        GenericSingleton<GameManager>.getInstance().HeroType = myType;
        Define.Hero heroData = GenericSingleton<DataManager>.getInstance().GetHeroInfo(myType);
        Define.WeaponType weaponType = (Define.WeaponType)System.Enum.Parse(typeof(Define.WeaponType), heroData.basicWeapon);
        hoveringCharacterBox = gameObject.transform;
        selectedBackground = hoveringCharacterBox.Find("SelectedImageBackground");
        cb.isBeforeBoxInfo(this);
        cb.SetData(myType, weaponType);
        cb.getMenuUIControllerData();
        selectedBackground.gameObject.SetActive(true);
        
        StartCoroutine(ClickBoxEvent());


    }

    public void OnClickedWeaponBox()
    {
        hoveringCharacterBox = gameObject.transform;
        selectedBackground = hoveringCharacterBox.Find("SelectedImageBackground");
        wb.isBeforeBoxInfo(this);
        selectedBackground.gameObject.SetActive(true);

        StartCoroutine(ClickBoxEvent());

        Define.WeaponType weaponType = (Define.WeaponType)System.Enum.Parse(typeof(Define.WeaponType), _name);
        wb.SetData(weaponType);
        wb.getMenuUIControllerData();
        // 업그레이드 버튼 기능 넣기(골드 소모 -> 강화 후 파일 데이터 반영
    }

    IEnumerator ClickBoxEvent()
    {
        while (true)
        {
            selectedBackground.DOScale(Maxv3, 1f).SetEase(Ease.Linear);
            yield return new WaitForSeconds(1);
            selectedBackground.DOScale(Minv3, 1f).SetEase(Ease.Linear);
            yield return new WaitForSeconds(0.5f);
        }
    }

}

