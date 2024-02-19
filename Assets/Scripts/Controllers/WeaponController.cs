using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    void Start()
    {
        SetStartSkill();

        List<Define.WeaponType> weaponTypes = GenericSingleton<GameManager>.getInstance().GetCurrentWeaponList();
        for (int i = 0; i < weaponTypes.Count; i++)
        {
            LoadWeapon(GenericSingleton<DataManager>.getInstance().GetWeaponInfo(weaponTypes[i], GenericSingleton<GameManager>.getInstance().GetCurrentWeaponLevel(weaponTypes[i])));
        }
    }

    private void SetStartSkill()
    {
        Define.HeroType type = GenericSingleton<GameManager>.getInstance().HeroType;
        if (type == Define.HeroType.SwordHero)
            GenericSingleton<GameManager>.getInstance().SetCurrentWeaponLevel(Define.WeaponType.Sword, 1);
        else
            GenericSingleton<GameManager>.getInstance().SetCurrentWeaponLevel(Define.WeaponType.Staff, 1);
    }

    public void LoadWeapon(Define.Weapon weaponData)
    {
        Define.WeaponType weaponType = (Define.WeaponType)weaponData.id;
        System.Type type = System.Type.GetType(weaponType.ToString());

        Component beforeWeapon = gameObject.GetComponent(type);
        if (beforeWeapon != null)
        {
            if (beforeWeapon is WeaponBase)
                (beforeWeapon as WeaponBase).Clear();
            Destroy(beforeWeapon);
        }

        var weapon = gameObject.AddComponent(type);
        if (weapon is WeaponBase)
            (weapon as WeaponBase).Init(weaponData);
        
        if (beforeWeapon == null)
            GenericSingleton<UIManager>.getInstance().GetUI<PlayerStatusUI>().AddItem(weaponData);
    }
}
