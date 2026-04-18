using System.Collections;
using Cysharp.Threading.Tasks;
using UnityEngine.SceneManagement;
using UnityEngine;

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

    float lastHitTime;
    public float _lastHitTime { get { return lastHitTime; } }

    float hitCooldown = 0.5f;
    public float _hitCooldown { get { return hitCooldown; } }

    float hp = 0f;
    public float _hP { get { return hp; } set { hp = value; } }

    bool _isDie = false;
    bool hit = false;   public bool _hit { get { return hit; } set { hit = value; } }
    

    void Start()
    {
        _isDie = false;
        lastHitTime = -hitCooldown; // 시작 즉시 피격 가능한 상태
        HeroDataSave();
        SetStateHero(new HeroMove());
    }

    void Update()
    {
        GenericSingleton<GameManager>.getInstance().SurviveTime += Time.deltaTime;
        _heroState.NowState();
        _heroState.HittedColer();

        if (Input.GetKeyDown(KeyCode.E))
            GenericSingleton<GameManager>.getInstance().GetExp(50);
    }

    public void MonsterInfo(Monster monster)
    {
        _mStat = monster.sendMonsterStat;
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.GetComponent<Monster>() != null)
        {
            MonsterInfo(collision.gameObject.GetComponent<Monster>());
            if (_hit == false) HittedWait().Forget();
        }
    }

    private async UniTaskVoid HittedWait()
    {
        _hit = true;
        Hitted();
        await UniTask.Delay(500, cancellationToken: this.GetCancellationTokenOnDestroy());
        _hit = false;
    }
    public void Hitted()
    {
        SoundManager.Instance.PlayHitSound();
        
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
        float vX = Input.GetAxisRaw("Horizontal");
        float vZ = Input.GetAxisRaw("Vertical");
        _hero._ani.SetFloat("AxisX", vX * _hero._heroData.moveSpeed);
        _hero._ani.SetFloat("AxisZ", vZ * _hero._heroData.moveSpeed);

        float vY = _hero.GetComponent<Rigidbody>().velocity.y;
        Vector3 v3 = new Vector3(vX, 0, vZ).normalized;
        Vector3 vYz = v3 * 4.5f;
        vYz.y += vY;
        _hero.GetComponent<Rigidbody>().velocity = vYz;

        if (Input.GetButton("Horizontal") && vX != 0)
            _hero.transform.rotation = Quaternion.LookRotation(new Vector3(vYz.x, 0, vYz.z));

        if (Input.GetButton("Vertical") && vZ != 0)
            _hero.transform.rotation = Quaternion.LookRotation(new Vector3(vYz.x, 0, vYz.z));
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
            _dieTimer += Time.deltaTime;
            if (_dieTimer >= 1f)
            {
                SoundManager.Instance.StopMusic(); 
                SoundManager.Instance.StopSound();
                
                GenericSingleton<UIManager>.getInstance().Clear();
                SceneManager.LoadScene("LastScene");
            }
        }
    }
}