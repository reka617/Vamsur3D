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

            // �������� ����ġ�� �ش�
            GenericSingleton<GameManager>.getInstance().GetExp(_monster.sendMonsterStat.exp);
            Debug.Log("��������ġ" + _monster.sendMonsterStat.exp);

            // ������Ʈ�� �ı��Ѵ�
            Destroy(_gemBase);
            Debug.Log("eat");
            
        }
    }

    private void Update()
    {
        //������ �����Ÿ� �������� ������̵����ϴ� ���� �߰�
        //õõ�� ���������� ���
        //��ġ�� ������ ���������
        transform.position = Vector3.Lerp(transform.position, GenericSingleton<GameManager>.getInstance().Player.transform.position, Time.deltaTime);
    }
}
