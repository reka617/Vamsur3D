using State;
using UnityEngine;


public class Monster : MonoBehaviour
{
    [SerializeField] GameObject _gem;
   // [SerializeField] Hero _hero;
    
    MonsterBase _mb;
    MonsterState _state;

    float _playerSkillDamage;
    bool isHit;

    public int _hp;//
    
    public float getDamage { get {return _mb.getMonsterStat.power; } } // 영웅에게 데미지를 주는 함수
    public Define.MonsterType sendMonsterType { get { return _mb.getMonsterType; } }
    public Define.Monster sendMonsterStat {  get { return _mb.getMonsterStat;} }
    public float sendSkillDamage { get { return _playerSkillDamage; } }
    public GameObject sendGemInfo { get { return _gem;} }

    public void Init(MonsterBase mb)
    {
        _mb = mb;
        _hp = _mb.getMonsterStat.hp;
        ChangeUnitState(new MoveState());
    }

    public void ChangeUnitState(MonsterState state)
    {
        _state = state;
        if (_state != null) _state.OnEnter(this);
    }
    private void Update()
    {
        if (_state == null)
        {
            _state = new MoveState();
            _state.OnEnter(this);
        }
        if (_state != null) _state.MainLoop();
        Debug.Log("현재 상태 :" + _state);
    }
   

  
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("PlayerSkill"))
        {
            _playerSkillDamage = other.gameObject.GetComponent<SkillProjectile>().Damage;
            ChangeUnitState(new HittedState());
            Debug.Log("hit");
        }
    }
}


public class ExpGem // 골드 클래스에서 position 계속 업데이트해줌
{



}
