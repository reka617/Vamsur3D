using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillProjectile : MonoBehaviour
{
    [SerializeField] GameObject _damageEffectOriginal;
    private float _damage = 0f;

    public float Damage { get { return _damage; } }

    public void Init(float damage)
    {
        _damage = damage;
    }

    protected virtual void OnTriggerEnterAction()
    {
        DamageEffect effect = Instantiate(_damageEffectOriginal, transform.position + Vector3.forward, Quaternion.Euler(40, 0, 0)).GetComponent<DamageEffect>();
        effect.SetText(_damage);
    }

    private void OnTriggerEnter(Collider other)
    {
        // tag�� �������� Ȯ���ؼ� ������ ���� ������ �ֱ�
        if (!other.CompareTag("Monster"))
            return;

        OnTriggerEnterAction();
    }
}
