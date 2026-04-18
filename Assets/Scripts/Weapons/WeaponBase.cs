using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    protected Define.WeaponType _weaponType;
    protected float _power;
    protected float _coolTime;
    protected int _projectileCount;
    protected float _projectileSpeed;
    protected int _enhanceLevel;

    public virtual void Init(Define.Weapon data)
    {
        InitSkill(data);
        StartSkill();
    }

    protected virtual void InitSkill(Define.Weapon data)
    {
        _weaponType = (Define.WeaponType)data.id;
        _power = data.power;
        _coolTime = data.coolTime;
        _projectileCount = data.projectileCount;
        _projectileSpeed = data.projectileSpeed;
        _enhanceLevel = GenericSingleton<DataManager>.getInstance().GetWeaponEnhanceLevel(_weaponType);
    }

    protected abstract void StartSkill();
    
    protected void PlayWeaponSound()
    {
        SoundManager.Instance.PlayWeaponSound(_weaponType);
    }

    protected float GetMouseDirAngle()
    {
        Vector3 mousePos = Vector3.zero;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo))
            mousePos = hitInfo.point;

        Vector3 dir = (mousePos - transform.position).normalized;
        float rad = Mathf.Atan2(dir.x, dir.z);

        return rad;
    }

    public float GetPower()
    {
        return _power * GenericSingleton<DataManager>.getInstance().GetWeaponEnhanceInfo(_weaponType, _enhanceLevel).power;
        //������ݷ�  * ����Ÿ�Կ� ���� ��ȭ�� ������ 
    }

    public abstract void Clear();
}
