using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DamageEffect : UIBase
{
    Vector3 _moveVec = new Vector3(0, 1f, 0);
    TMP_Text _damageText;
    float _damage;
    float _speed = 3f;
    float _lifeTime = 0.5f;
    float _timer = 0;


    public void SetText(float damage)
    {
        _damage = damage;
    }

    public override void Init()
    {
        _damageText = gameObject.GetComponentInChildren<TMP_Text>();
        _damageText.text = _damage.ToString();
    }

    void Update()
    {
        Vector3 endVec = transform.position + _moveVec;
        transform.position = Vector3.Lerp(transform.position, endVec, Time.deltaTime * _speed);

        _timer += Time.deltaTime;
        if (_timer > _lifeTime)
        {
            Destroy(gameObject);
        }
    }
}
