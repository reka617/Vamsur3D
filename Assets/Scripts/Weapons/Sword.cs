using System.Collections;
using UnityEngine;

public class Sword : WeaponBase
{
    GameObject _attackJudge; // 스킬오브젝트
    float _rebound; // 스킬범위를 위한 변수
    float _detectTime;  //스킬라이프타임

    protected override void InitSkill(Define.Weapon data)
    {
        base.InitSkill(data);

        _rebound = 1f; 
        _detectTime = 0.5f;
        _attackJudge = Resources.Load<GameObject>("Prefabs/Weapons/Slash");
    }

    protected override void StartSkill()
    {
        StartCoroutine(CoSkill());
    }

    IEnumerator CoSkill()
    {
        while (true)
        {
            for (int i = 0; i < _projectileCount; i++)
            {
                Skill();
                yield return new WaitForSeconds(0.2f);
            }

            yield return new WaitForSeconds(_coolTime);
        }
    }

    void Skill()
    {
        GameObject skillJudgeInstance = Instantiate(_attackJudge);
        skillJudgeInstance.GetComponent<SkillProjectile>().Init(GetPower());
        // transform.rotaion으로 벡터 구해보기
        float rad = GetMouseDirAngle();
        float tempRad = Random.Range(rad - _rebound, rad + _rebound);
        Vector3 vec = new Vector3(Mathf.Sin(tempRad), 0f, Mathf.Cos(tempRad));

        skillJudgeInstance.transform.position = transform.position + vec * 1.5f + Vector3.up;
        skillJudgeInstance.transform.rotation = Quaternion.AngleAxis(tempRad * Mathf.Rad2Deg, Vector3.up);

        Destroy(skillJudgeInstance, _detectTime);
    }

    public override void Clear()
    {

    }
}
