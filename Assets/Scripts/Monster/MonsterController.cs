using System.Collections;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public bool IsRespawnCoolTime { get; set; }
    bool isRespawnCoolTime = false;
    bool isRespawn = false;
    //몬스터 강화 킬카운트
    //엘리트 몬스터 소환되는 킬카운트 200단위
    //몬스터 총량 킬카운트, 엘리트몬스터는 총량 하나로 고 정,
    // >> 킬카운트 100단위 100 총량 200단위일떈 강화
    //임시 5씩 늘어남 일반몹, 투사체
    private void Start()
    {
    
    }

    private void Update()
    {
        if(GenericSingleton<GameManager>.getInstance().KillCount % 5 != 0)
        {
            isRespawn = false;
        }
        if (isRespawnCoolTime == false)
        {
            StartCoroutine(RespawnCollTime());
        }
        if(GenericSingleton<GameManager>.getInstance().KillCount > 1 && GenericSingleton<GameManager>.getInstance().KillCount % 5 == 0 && isRespawn == false)
        {
            GenericSingleton<MonsterFactory>.getInstance().SummonEliteMonster();
            isRespawn = true;
        }
    }


    IEnumerator RespawnCollTime()
    {
        isRespawnCoolTime = true;
        GenericSingleton<MonsterFactory>.getInstance().SummonMonster();
        Debug.Log("소환");
        yield return new WaitForSeconds(3.0f);
        isRespawnCoolTime = false;
    }
}
  


