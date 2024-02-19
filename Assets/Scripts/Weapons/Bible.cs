using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bible : WeaponBase
{
    GameObject _original;
    List<GameObject> _bibles = new List<GameObject>();

    float _range = 3f;
    float _lifeTime = 3f;

    protected override void InitSkill(Define.Weapon data)
    {
        base.InitSkill(data);

        _original = Resources.Load<GameObject>("Prefabs/Weapons/Bible");

        for (int i = 0; i < _projectileCount; i++)
        {
            float rotDeg = 0f + (360f / _projectileCount) * i;
            GameObject instance = Instantiate(_original, transform);
            instance.GetComponent<SkillProjectile>().Init(GetPower());
            instance.transform.localPosition = new Vector3(Mathf.Sin(rotDeg * Mathf.Deg2Rad), 0f, Mathf.Cos(rotDeg * Mathf.Deg2Rad)) * _range;

            _bibles.Add(instance);
        }
    }

    protected override void StartSkill()
    {
        StartCoroutine(CoSkill());
    }

    IEnumerator CoSkill()
    {
        bool isActive = true;
        float timer = 0f;

        while (true)
        {
            if (isActive)
            {
                // 소환
                foreach (GameObject bible in _bibles)
                    bible.SetActive(true);

                while (timer < _lifeTime)
                {
                    // 회전
                    for (int i = 0; i < _bibles.Count; i++)
                    {
                        float rotDeg = (360f / _projectileCount) * i + timer * _projectileSpeed;
                        _bibles[i].transform.position = transform.position + new Vector3(Mathf.Sin(rotDeg * Mathf.Deg2Rad), 0f, Mathf.Cos(rotDeg * Mathf.Deg2Rad)) * _range + Vector3.up;
                    }

                    timer += Time.deltaTime;
                    yield return null;
                }

                isActive = false;
                timer = 0f;
            }
            else
            {
                // 삭제
                foreach (GameObject bible in _bibles)
                    bible.SetActive(false);

                isActive = true;
                
                yield return new WaitForSeconds(_coolTime);
            }
        }
    }

    public override void Clear()
    {
        foreach (var instance in _bibles)
            Destroy(instance);

        _bibles.Clear();
    }
}
