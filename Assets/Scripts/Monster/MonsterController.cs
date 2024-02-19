using System.Collections;
using UnityEngine;

public class MonsterController : MonoBehaviour
{
    public bool IsRespawnCoolTime { get; set; }
    bool isRespawnCoolTime = false;
    bool isRespawn = false;
    //���� ��ȭ ųī��Ʈ
    //����Ʈ ���� ��ȯ�Ǵ� ųī��Ʈ 200����
    //���� �ѷ� ųī��Ʈ, ����Ʈ���ʹ� �ѷ� �ϳ��� �� ��,
    // >> ųī��Ʈ 100���� 100 �ѷ� 200�����ϋ� ��ȭ
    //�ӽ� 5�� �þ �Ϲݸ�, ����ü
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
        Debug.Log("��ȯ");
        yield return new WaitForSeconds(3.0f);
        isRespawnCoolTime = false;
    }
}
  


