using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Dictionary<Define.WeaponType, int> _playerWeaponLevels = new Dictionary<Define.WeaponType, int>();

    public GameObject Player { get; set; } // Hero��ũ��Ʈ�� �������ִ� ���ӿ�����Ʈ�� start�Ҷ� set
    public Define.HeroType HeroType { get; set; } = Define.HeroType.SwordHero;//SwordHero//Wizard �� �޴������� ����ȯ�� set���ش�
    
    public int HeroLv { get; set; }
    public int HeroExp { get; set; }
    public float SurviveTime { get; set; }
    public int KillCount { get; set; }
    public int TotalGold { get; set; } = 501;
    public int StageGold { get; set; }
    public float TotalDmg { get; set; }

    public void GameStart()
    {
        SoundManager.Instance.PlayBGM();
        
        HeroLv = 1;
        HeroExp = 0;
        SurviveTime = 0f;
        KillCount = 0;
        StageGold = 0;
        TotalDmg = 0f;
        Debug.Log(TotalGold);
    }

    public void GetExp(int exp)
    {
        HeroExp += exp;
        Debug.Log($"HeroExp: {HeroExp} HeroLv: {HeroLv}");
        if (HeroExp >= HeroLv * 100) 
        {
            HeroLv++;
            GenericSingleton<UIManager>.getInstance().GetUI<PlayerStatusUI>().SetLv(HeroLv);
            GenericSingleton<UIManager>.getInstance().GetUI<WeaponSelectUI>().Open();
        }
    }

    public List<Define.WeaponType> GetCurrentWeaponList()
    {
        return new List<Define.WeaponType>(_playerWeaponLevels.Keys);
    }

    public int GetCurrentWeaponLevel(Define.WeaponType type)
    {
        return _playerWeaponLevels[type];
    }

    public void SetCurrentWeaponLevel(Define.WeaponType type, int level)
    {
        if (_playerWeaponLevels.ContainsKey(type))
        {
            _playerWeaponLevels[type] = level;
        }
        else
        {
            _playerWeaponLevels.Add(type, level);
        }
    }

    public bool UpgradeWeaponEnhanceLevel(Define.WeaponType weaponType)//�޴��� ������׷��̵�
    {
        int curEnhanceLevel = GenericSingleton<DataManager>.getInstance().GetWeaponEnhanceLevel(weaponType);
        int cost = GenericSingleton<DataManager>.getInstance().GetWeaponEnhanceInfo(weaponType, curEnhanceLevel).cost;
        if (TotalGold > cost)
        {
            TotalGold -= cost;
            GenericSingleton<DataManager>.getInstance().SetWeaponEnhanceLevel(weaponType, curEnhanceLevel + 1);
            return true;
        }

        return false;
    }

    public void Clear()
    {
        Player = null;
        HeroType = Define.HeroType.None;
        _playerWeaponLevels.Clear();
        HeroLv = 0;
        HeroExp = 0;
        SurviveTime = 0f;
        KillCount = 0;
        StageGold = 0;
        TotalDmg = 0f;
    }
}