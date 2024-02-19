using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gem : MonoBehaviour//경험치
{
    [SerializeField] GameObject _gemBase;
    Monster _monster;
    

    public void Init(Monster monster)
    {
        _monster = monster;
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {

            // 영웅에게 경험치를 준다
            GenericSingleton<GameManager>.getInstance().GetExp(_monster.sendMonsterStat.exp);
            Debug.Log("보낸경험치" + _monster.sendMonsterStat.exp);

            // 오브젝트를 파괴한다
            Destroy(_gemBase);
            Debug.Log("eat");
            
        }
    }

    private void Update()
    {
        //영웅이 일정거리 들어왔을때 끌어들이도록하는 조건 추가
        //천천히 딸려오도록 고려
        //위치는 영웅을 따라오도록
        transform.position = Vector3.Lerp(transform.position, GenericSingleton<GameManager>.getInstance().Player.transform.position, Time.deltaTime);
    }
}
