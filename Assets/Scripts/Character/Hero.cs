using UnityEngine.SceneManagement;
using UnityEngine;
using System.Collections;
enum EHeroMove
{
    Idle,
    die,
}
public class Hero : MonoBehaviour
{
    HeroState _heroState;
    HeroTypeCheck _heroTypeCheck = new HeroTypeCheck();
    Define.Monster _mStat;
    Define.Hero heroData;
    public Define.Hero _heroData { get { return heroData; } set { heroData = value; } }
    SkinnedMeshRenderer render;
    public SkinnedMeshRenderer _render { get { return render; } set { render = value; } }

    Animator ani;
    public Animator _ani { get { return ani; } set { ani = value; } }

    Color heroColor;
    public Color _heroColor { get { return heroColor; } set { heroColor = value; } }
    Vector3 fors;
    public Vector3 _fors { get { return fors; } set { fors = value; } }
    bool hit = false;   public bool _hit { get { return hit; } set { hit = value; } }
    float hp = 0f;   public float _hP { get { return hp; } set { hp = value; } }
    bool _isDie = false; 
    void Start()
    {
        _isDie = false;
        HeroDataSave();
        Debug.Log(_ani);
        Debug.Log(GenericSingleton<GameManager>.getInstance().SurviveTime);
        _heroState = new HeroMove();
        SetStateHero(new HeroMove());// 상태 저장,실행
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.P))
        {
            SetStateHero(new DieState());
        }
        GenericSingleton<GameManager>.getInstance().SurviveTime += Time.deltaTime;
        _heroState.NowState();
        _heroState.HittedColer();
        // 경험치 획득 임시 코드 // 몬스터가 죽었을때 실행하게 몬스터 코드에 있는게 맞음 몬스터 마다 경험치가 다르니
        if (Input.GetKeyDown(KeyCode.E))
            GenericSingleton<GameManager>.getInstance().GetExp(50);
    }
    public void MonsterInfo(Monster monster)
    {
        Debug.Log("MonsterInfo" + (_mStat == null));
        _mStat = monster.sendMonsterStat;
    }
    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.GetComponent<Monster>() != null)
        {
            MonsterInfo(collision.gameObject.GetComponent<Monster>());
            if (_hit == false) StartCoroutine(HittedWait());
        }
    }
    IEnumerator HittedWait()
    {
        _hit = true;
        Hitted();
        yield return new WaitForSeconds(0.5f);
        _hit = false;
    }
    public void Hitted()
    {
        _hP -= _mStat.power;
        Debug.Log(_hP);
        if (_hP <= 0&&_isDie == false)
        {
            _isDie = true;
            SetStateHero(new DieState());
        }
    }
    public void SetStateHero(HeroState state)
    {
        _heroState = state;
        _heroState.OnEnter(this);
    }
    void HeroDataSave()
    {
       _heroTypeCheck.HeroCheck(GenericSingleton<GameManager>.getInstance().HeroType);
        _heroData = _heroTypeCheck._heroData;
        _ani = GetComponentInChildren<Animator>();
        _render = GetComponentInChildren<SkinnedMeshRenderer>();
        _heroColor = _render.material.color;
        _hP = _heroData.hp;
        GenericSingleton<GameManager>.getInstance().Player = gameObject;
    }
}
public class HeroState
{
    protected Hero _hero;
   protected float _dieTimer, _hitTimer = 0f;
    public virtual void OnEnter(Hero hero)
    {
        _hero = hero;
    }
    public virtual void HeroDieState() { }
    public virtual void NowState() { }
    public void HittedColer()
    {
        if (_hero._hit == true)
        {
            _hitTimer += Time.deltaTime;
            _hero._render.material.color = Color.red;
        }
        if (_hero._hit == false)
        {
            _hero._render.material.color = _hero._heroColor;
            _hitTimer = 0f;
        }
    }
}
public class HeroMove : HeroState
{
    public override void OnEnter(Hero hero)
    {
        base.OnEnter(hero);
    }
    public override void NowState()
    {
        float vX = Input.GetAxisRaw("Horizontal");//0=>1D==     -1,1,0값이 계속들어옴
        float vZ = Input.GetAxisRaw("Vertical");//GetAxis 0=0.1=0.2=0.3===1
        _hero._ani.SetFloat("AxisX", vX * _hero._heroData.moveSpeed);
        _hero._ani.SetFloat("AxisZ", vZ * _hero._heroData.moveSpeed);
        float vY = _hero.GetComponent<Rigidbody>().velocity.y; //velocity == Rigidbody 속도
        Vector3 v3 = new Vector3(vX, 0, vZ).normalized;
        Vector3 vYz = v3 * 4.5f;
        vYz.y += vY;
        _hero.GetComponent<Rigidbody>().velocity = vYz;
        if (Input.GetButton("Horizontal") && vX != 0)
        {
            _hero.transform.rotation = Quaternion.LookRotation(new Vector3(vYz.x, 0, vYz.z));
        }
        if (Input.GetButton("Vertical") && vZ != 0)
        {
            _hero.transform.rotation = Quaternion.LookRotation(new Vector3(vYz.x, 0, vYz.z));
        }
    
    }
}
public class DieState : HeroState
{
    public override void OnEnter(Hero hero)
    {
        base.OnEnter(hero);
    }
    public override void NowState()
    {
        _hero._ani.SetInteger("HeroMove", (int)EHeroMove.die);
        _hero.GetComponent<Rigidbody>().velocity = Vector3.zero;
        _hero.SetStateHero(new Scenechange());
    }
    public class Scenechange : HeroState
    {
        public override void OnEnter(Hero hero)
        {
            base.OnEnter(hero);
        }
        public override void NowState()
        {
            Debug.Log("Scenechange");
            _dieTimer += Time.deltaTime;
            if (_dieTimer >= 1f)
            {
                GenericSingleton<UIManager>.getInstance().Clear();
                SceneManager.LoadScene("LastScene");
            }
        }
    }
}