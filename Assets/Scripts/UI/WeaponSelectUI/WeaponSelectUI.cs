using System.Collections.Generic;
using UnityEngine;

public class WeaponSelectUI : UIBase
{
    GameObject _subitemRoot;
    GameObject _subItem;

    List<WeaponSelectItemUI> _subItems;

    public override void Init()
    {
        _subitemRoot = transform.Find("Panel").gameObject;
        _subItem = Resources.Load<GameObject>("Prefabs/UI/WeaponSelectUI/WeaponSelectItemUI");

        _subItems = new List<WeaponSelectItemUI>();
    }

    void Update()
    {
        // 모든 아이템이 최고레벨이라서 선택할 게 없을 때만 동작하도록 수정 필요
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Close();
        }
    }

    public void Open()
    {
        // active true
        gameObject.SetActive(true);

        // subItem 로드 3개만 생성
        for (int i = 0; i < 3; i++)
        {
            MakeSubItem();
        }

        Time.timeScale = 0f;
    }

    public void Close()
    {
        // active false
        gameObject.SetActive(false);

        // subItem 삭제
        for (int i = 0; i < _subItems.Count; i++)
            Destroy(_subItems[i].gameObject);
        _subItems.Clear();

        Time.timeScale = 1f;
    }

    void MakeSubItem()
    {
        // 랜덤으로 얻을 수 있는 weapon 뽑기
        // 중복은 피하고
        // weapon 정보 전달
        Define.WeaponType randomWeaponType = Define.WeaponType.None;
        while (true)
        {
            randomWeaponType = (Define.WeaponType)Random.Range((int)Define.WeaponType.None + 1, (int)Define.WeaponType.Boomerang);

            bool isUnique = true;
            foreach (WeaponSelectItemUI item in _subItems)
            {
                if (item.weaponInfo.id == (int)randomWeaponType)
                    isUnique = false;
            }

            if (isUnique)
                break;
        }

        int randomWeaponLevel = GenericSingleton<GameManager>.getInstance().GetCurrentWeaponList().Contains(randomWeaponType) ? GenericSingleton<GameManager>.getInstance().GetCurrentWeaponLevel(randomWeaponType) + 1 : 1;
        Define.Weapon weapon = null;
        try
        {
            weapon = GenericSingleton<DataManager>.getInstance().GetWeaponInfo(randomWeaponType, randomWeaponLevel);
            GameObject instance = Instantiate(_subItem, _subitemRoot.transform);
            WeaponSelectItemUI weaponSelectItemUI = instance.GetComponent<WeaponSelectItemUI>();
            _subItems.Add(weaponSelectItemUI);
            weaponSelectItemUI.Init(weapon);
        }
        catch (KeyNotFoundException e)
        {
            Debug.Log($"{randomWeaponType}은 최고레벨입니다");
            // 다른 무기를 찾고 모든 무기가 최고레벨인지도 체크 필요
        }
    }
}
