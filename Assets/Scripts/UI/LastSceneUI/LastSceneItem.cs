using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class LastSceneItem : MonoBehaviour
{
    [SerializeField] Image _Image;
    [SerializeField] Text _name;
    [SerializeField] Text _lv;
    [SerializeField] Text _dmg;
    [SerializeField] Text _dps;
    [SerializeField] Text _kills;
   // public void init(ItemData data, WeaponData weaponData)//�������� �޾Ƽ� ��°� ����
    public void init()//�������� �޾Ƽ� ��°� ����
    {
        Debug.Log("init");
       // _weaponData =  GenericSingleton<GameManager>.getInstance().TotalDmg;
        _name.text = "" +GenericSingleton<GameManager>.getInstance().name;
        _lv.text = " LV." + GenericSingleton<GameManager>.getInstance().HeroLv;
        _dmg.text = "���ⵥ���� : " + GenericSingleton<GameManager>.getInstance().TotalDmg;
        _dps.text = " DPS: " + GenericSingleton<GameManager>.getInstance().TotalDmg/GenericSingleton<GameManager>.getInstance().SurviveTime;
        _kills.text = " ų��: " + GenericSingleton<GameManager>.getInstance().KillCount;
        Debug.Log(GenericSingleton<GameManager>.getInstance().TotalDmg);
        Debug.Log(GenericSingleton<GameManager>.getInstance().SurviveTime);
        Debug.Log(GenericSingleton<GameManager>.getInstance().TotalDmg/ GenericSingleton<GameManager>.getInstance().SurviveTime);
    }
}
