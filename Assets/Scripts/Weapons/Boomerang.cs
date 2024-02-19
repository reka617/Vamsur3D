using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boomerang : WeaponBase
{
    GameObject _original;

    protected override void InitSkill(Define.Weapon data)
    {
        base.InitSkill(data);

        _original = Resources.Load<GameObject>("Prefabs/Weapons/Boomerang");
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
                float rot = GetMouseDirAngle();
                Vector3 mouseVec = new Vector3(Mathf.Sin(rot), 0f, Mathf.Cos(rot));
                GameObject instance = Instantiate(_original);
                instance.transform.position = transform.position + Vector3.up + mouseVec * 2f;
                instance.GetComponent<SkillProjectile>().Init(GetPower());
                instance.GetComponent<BoomerangProjectile>().SetData(mouseVec, _projectileSpeed);

                yield return new WaitForSeconds(0.2f);
            }

            yield return new WaitForSeconds(_coolTime);
        }
    }

    public override void Clear()
    {

    }
}
