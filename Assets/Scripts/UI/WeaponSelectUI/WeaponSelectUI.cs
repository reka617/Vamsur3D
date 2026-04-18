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
        // ��� �������� �ְ������̶� ������ �� ���� ���� �����ϵ��� ���� �ʿ�
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Close();
        }
    }

    public void Open()
    {
        // active true
        gameObject.SetActive(true);

        // subItem �ε� 3���� ����
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

        // subItem ����
        for (int i = 0; i < _subItems.Count; i++)
            Destroy(_subItems[i].gameObject);
        _subItems.Clear();

        Time.timeScale = 1f;
    }

    void MakeSubItem()
    {
        // �������� ���� �� �ִ� weapon �̱�
        // �ߺ��� ���ϰ�
        // weapon ���� ����
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
            Debug.Log($"{randomWeaponType}�� �ְ������Դϴ�");
            // �ٸ� ���⸦ ã�� ��� ���Ⱑ �ְ����������� üũ �ʿ�
        }
    }
}
