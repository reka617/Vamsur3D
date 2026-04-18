using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireField : WeaponBase
{
    GameObject _original;

    float _lifeTime = 3f;

    // power�� ���� �������� � �� ����
    // ũ�� ���� �����ϵ��� ����

    protected override void InitSkill(Define.Weapon data)
    {
        base.InitSkill(data);
        _original = Resources.Load<GameObject>("Prefabs/Weapons/FireField");
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
                PlayWeaponSound();
                Vector3 spawnPos = transform.position + new Vector3(Random.Range(-10f, 10f), 0.2f, Random.Range(-10f, 10f));
                GameObject instance = Instantiate(_original, spawnPos, Quaternion.identity);
                instance.GetComponent<SkillProjectile>().Init(GetPower());
                Destroy(instance, _lifeTime);
            }
            
            yield return new WaitForSeconds(_coolTime);
        }
    }

    public override void Clear()
    {

    }
}
