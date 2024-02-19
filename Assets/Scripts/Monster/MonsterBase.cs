using UnityEngine;

public abstract class MonsterBase
{
    protected GameObject _obj;
    protected Define.Monster _monStat;
    protected Define.MonsterType _monType;

    public Define.MonsterType getMonsterType { get { return _monType; } }
    public Define.Monster getMonsterStat { get { return _monStat; } }

    public abstract void Init();

}

public class NormalMonster : MonsterBase
{
    public override void Init()
    {
        _obj = GenericSingleton<MonsterPool>.getInstance().GetPoolObject(Define.MonsterType.NormalMob);
        _monStat = GenericSingleton<DataManager>.getInstance().GetMonsterInfo(Define.MonsterType.NormalMob);
        _monType = Define.MonsterType.NormalMob;
        _obj.GetComponent<Monster>().Init(this);
        _obj.SetActive(true);
        _obj.transform.position =  new Vector3(Random.Range(-20f, 20), 0.5f, Random.Range(-20f, 20f));
        
    }
}

public class ProjectileMonster : MonsterBase
{
    public override void Init()
    {
        _obj = GenericSingleton<MonsterPool>.getInstance().GetPoolObject(Define.MonsterType.ProjectileMob);
        _monStat = GenericSingleton<DataManager>.getInstance().GetMonsterInfo(Define.MonsterType.ProjectileMob);
        _monType = Define.MonsterType.ProjectileMob;
        _obj.GetComponent<Monster>().Init(this);
        _obj.SetActive(true);
        _obj.transform.position =  new Vector3(Random.Range(-20f, 20), 0.5f, Random.Range(-20f, 20f));
    }
}

public class EliteMonster : MonsterBase
{
    public override void Init()
    {
        _obj = GenericSingleton<MonsterPool>.getInstance().GetPoolObject(Define.MonsterType.EliteMob);
        _monStat = GenericSingleton<DataManager>.getInstance().GetMonsterInfo(Define.MonsterType.EliteMob);
        _monType = Define.MonsterType.EliteMob;
        _obj.GetComponent<Monster>().Init(this);
        _obj.SetActive(true);
        _obj.transform.position =  new Vector3(Random.Range(-20f, 20), 0.75f, Random.Range(-20f, 20f));
    }
}



