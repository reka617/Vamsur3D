using System.Collections;
using UnityEngine;

public class Staff : WeaponBase
{
    GameObject _arrow;
    float _arrowSpeed;
    protected override void InitSkill(Define.Weapon data)
    {
        base.InitSkill(data);

        _coolTime = data.coolTime;
        _arrowSpeed = data.projectileSpeed;
        _arrow = Resources.Load<GameObject>("Prefabs/Weapons/Redfire");
    }

    protected override void StartSkill()
    {
        StartCoroutine(CoFire());
    }

    IEnumerator CoFire()
    {
        while (true)
        {
            for (int i = 0; i < _projectileCount; i++)
            {
                Fire();
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(_coolTime);
        }
    }

    void Fire()
    {
        float rad = GetMouseDirAngle();
        // 해당 각도로 발사
        Vector3 moveVec = new Vector3(Mathf.Sin(rad), 0f, Mathf.Cos(rad));

        GameObject instance = Instantiate(_arrow, transform.position + moveVec + Vector3.up, Quaternion.AngleAxis(rad * Mathf.Rad2Deg, Vector3.up));
        instance.GetComponent<SkillProjectile>().Init(GetPower());
        instance.GetComponent<Rigidbody>().AddForce(moveVec * _arrowSpeed);
        Destroy(instance, 5f);
    }

    public override void Clear()
    {

    }
}
