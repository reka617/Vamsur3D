using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Gem : MonoBehaviour//����ġ
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
            GenericSingleton<GameManager>.getInstance().GetExp(_monster.sendMonsterStat.exp);
            Debug.Log("��������ġ" + _monster.sendMonsterStat.exp);

            Destroy(_gemBase);
            Debug.Log("eat");
            
        }
    }

    private void Update()
    {
        if (Vector3.Distance(transform.position, GenericSingleton<GameManager>.getInstance().Player.transform.position) < 10f)
        {
            transform.position = Vector3.Lerp(transform.position, GenericSingleton<GameManager>.getInstance().Player.transform.position, Time.deltaTime);
        }
       
        
    }
}
