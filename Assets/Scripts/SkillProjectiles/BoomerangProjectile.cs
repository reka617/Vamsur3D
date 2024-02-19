using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoomerangProjectile : SkillProjectile
{
    Vector3 _moveVec;
    float _speed;
    float _lifeTime = 5f;
    float _lifeTimer = 0f;

    public void SetData(Vector3 moveVec, float speed)
    {
        _moveVec = moveVec;
        _speed = speed;
    }

    void Update()
    {
        _lifeTimer += Time.deltaTime;
        if (_lifeTimer >= _lifeTime )
            Destroy(gameObject);

        Move();
    }

    void Move()
    {
        transform.position += _moveVec * Time.deltaTime * _speed * 10f;
    }

    protected override void OnTriggerEnterAction()
    {
        base.OnTriggerEnterAction();

        Reverse();
    }

    private void Reverse()
    {
        _moveVec = _moveVec * -1f;
    }
}
