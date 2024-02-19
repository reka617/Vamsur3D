using System.Collections.Generic;
using UnityEngine;

public class MonsterFactory : MonoBehaviour
{
    List<MonsterFactoryBase> monFactories = new List<MonsterFactoryBase>();
   
    public int killCount;
    void Init()
    {
        if (monFactories.Count > 0) return;
        monFactories.Add(new NormolMobFactory());
        monFactories.Add(new ProjectileMobFactory());
        monFactories.Add(new EliteMobFactory());
    }

    public MonsterBase SummonMonster()
    {
        Init();
        int i = Random.Range(0, monFactories.Count-1);
        return monFactories[i].MakeMonster();
    }

    public MonsterBase SummonEliteMonster()
    {
        Init();
        return monFactories[2].MakeMonster();
    }

}

public abstract class MonsterFactoryBase
{
    
    public abstract MonsterBase MakeMonster();
}

public class NormolMobFactory : MonsterFactoryBase
{
    public override MonsterBase MakeMonster()
    {
        MonsterBase mon = new NormalMonster();
        mon.Init();
        return mon;
    }
}

public class ProjectileMobFactory : MonsterFactoryBase
{
    public override MonsterBase MakeMonster()
    {
        MonsterBase mon = new ProjectileMonster();
        mon.Init();
        return mon;
    }
}

public class EliteMobFactory : MonsterFactoryBase
{
    public override MonsterBase MakeMonster()
    {
        MonsterBase mon = new EliteMonster();
        mon.Init();
        return mon;
    }
}
