using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    private Dictionary<Define.HeroType, Define.Hero> _heroDict;
    private Dictionary<Define.WeaponType, Dictionary<int, Define.Weapon>> _weaponDict;
    private Dictionary<Define.WeaponType, List<Define.WeaponEnhanceData>> _weaponEnhanceDict; //무기강화테이블
    private Dictionary<Define.WeaponType, int> _currentWeaponEnhanceDict; // 게임중반영된정보
    private Dictionary<Define.MonsterType, Define.Monster> _monsterDict;

    public Dictionary<Define.WeaponType, Dictionary<int, Define.Weapon>> WeaponDict { get { return _weaponDict; } }
    public Dictionary<Define.HeroType, Define.Hero> HeroDict { get { return _heroDict; } }

    void Awake()
    {
        Init();
    }

    void Init()
    {
        // 캐릭터 정보 로드
        _heroDict = Util.LoadJsonDict<Define.HeroType, Define.Hero>("Data/HeroData");

        // 무기 정보 로드
        _weaponDict = Util.LoadJsonDict<Define.WeaponType, Dictionary<int, Define.Weapon>>("Data/WeaponData");
        _weaponEnhanceDict = Util.LoadJsonDict<Define.WeaponType, List<Define.WeaponEnhanceData>>("Data/WeaponInhanceData");
        if(!Directory.Exists(Application.persistentDataPath + "/VamSurData"))// 폴더가 없을 경우 폴더 생성
        {
            Directory.CreateDirectory(Application.persistentDataPath + "/VamSurData");
        }

        if (File.Exists(Application.persistentDataPath + "/VamSurData/CurrentWeaponInhanceData.json")) // 파일이 있을 경우 그대로 읽기
        {
            _currentWeaponEnhanceDict = Util.LoadJsonDict<Define.WeaponType, int>(Application.persistentDataPath + "/VamSurData/CurrentWeaponInhanceData.json");
        }
        else // 없으면 초기 json파일을 copy해와서 persistentDataPath에 넣어줌, 그 후 읽음
        {
            MoveJsonFile();
            _currentWeaponEnhanceDict = Util.LoadJsonDict<Define.WeaponType, int>(Application.persistentDataPath + "/VamSurData/CurrentWeaponInhanceData.json");
        }

        //몬스터 정보 로드
        _monsterDict = Util.LoadJsonDict<Define.MonsterType, Define.Monster>("Data/MonsterData");
    }

    public void MoveJsonFile()
    {
        string sourceDir = "Assets/Resources/Data";
        string moveDir = Application.persistentDataPath + "/VamSurData";

        string[] JsonList = Directory.GetFiles(sourceDir, "CurrentWeaponInhanceData.json");

        foreach (string f in JsonList)
        {
            string fName = f.Substring(sourceDir.Length + 1);
            File.Copy(Path.Combine(sourceDir, fName), Path.Combine(moveDir, fName));
        }
        
    }

    public Define.Hero GetHeroInfo(Define.HeroType type)
    {
        return _heroDict[type];
    }

    public Define.Weapon GetWeaponInfo(Define.WeaponType weaponType)
    {
        return GetWeaponInfo(weaponType, 1);
    }

    public Define.Weapon GetWeaponInfo(Define.WeaponType weaponType, int level)
    {
        return _weaponDict[weaponType][level];
    }

    public Define.WeaponEnhanceData GetWeaponEnhanceInfo(Define.WeaponType weaponType, int enhanceLevel)
    {
        return _weaponEnhanceDict[weaponType][enhanceLevel];
    }

    public int GetWeaponEnhanceLevel(Define.WeaponType weaponType)
    {
        return _currentWeaponEnhanceDict[weaponType];
    }

    public void SetWeaponEnhanceLevel(Define.WeaponType weaponType, int level)
    {
        _currentWeaponEnhanceDict[weaponType] = level;
        // 데이터 저장
        Util.SaveJson(_currentWeaponEnhanceDict,"VamSurData", "CurrentWeaponInhanceData.json");
    }

    public Define.Monster GetMonsterInfo(Define.MonsterType monsterType)
    {
        return _monsterDict[monsterType];
    }
}
