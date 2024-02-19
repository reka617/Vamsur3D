using UnityEngine;


namespace State
{
    public class MonsterState
    {
        protected Monster _monster;
        public virtual void OnEnter(Monster monster)
        {
            _monster = monster;
        }

        public virtual void MainLoop()
        {

        }
    }

    public class MoveState : MonsterState
    {
        Hero _hero;  // Transform trans;
        int monsterSpeed = 2;
        public override void OnEnter(Monster monster)
        {
            base.OnEnter(monster);
        }
        public override void MainLoop()
        {
            if (GenericSingleton<UIManager>.getInstance().IsStop) monsterSpeed = 0;
            else monsterSpeed = 2;
            _hero = GenericSingleton<GameManager>.getInstance().Player.gameObject.GetComponent<Hero>();
            // trans = GenericSingleton<GameManager>.getInstance().Player.gameObject.transform;//Hero스크립트를 받을 이유가 안보임
            //플레이어를 따라가도록 하는 기능
            _monster.transform.LookAt(new Vector3(_hero.transform.position.x, _monster.transform.position.y, _hero.transform.position.z));

            _monster.transform.position = Vector3.MoveTowards(_monster.transform.position, _hero.transform.position, Time.deltaTime * monsterSpeed);
        }
    }

    public class HittedState : MonsterState
    {
        public override void OnEnter(Monster monster)
        {
            base.OnEnter(monster);
        }
        
        public override void MainLoop()
        {
            if (_monster.sendMonsterType == Define.MonsterType.NormalMob)
            {
               _monster._hp -= (int)_monster.sendSkillDamage;
                if (_monster._hp <= 0)
                {
                    _monster.ChangeUnitState(new DieState());
                }
                else
                {
                    _monster.ChangeUnitState(new MoveState());
                }
            }
            else if (_monster.sendMonsterType == Define.MonsterType.ProjectileMob)
            {
                _monster._hp -= (int)_monster.sendSkillDamage;
                if(_monster._hp <= 0)
                {
                    _monster.ChangeUnitState(new DieState());
                }
                else
                {
                    _monster.ChangeUnitState(new MoveState());
                }
            }
            else if (_monster.sendMonsterType == Define.MonsterType.EliteMob)
            {
                _monster._hp -= (int)_monster.sendSkillDamage;
                if (_monster._hp <= 0)
                {
                    _monster.ChangeUnitState(new DieState());
                }
                else
                {
                    _monster.ChangeUnitState(new MoveState());
                }

            }
        }
    }

    public class DieState : MonsterState
    {
        public override void OnEnter(Monster monster)
        {
            base.OnEnter(monster);
        }

        public override void MainLoop()
        {
            _monster.gameObject.SetActive(false);
            GenericSingleton<GameManager>.getInstance().KillCount++;
            GameObject tmp = Object.Instantiate(_monster.sendGemInfo);
            tmp.transform.position = _monster.transform.position;
            tmp.GetComponent<Gem>().Init(_monster);
            
        }
    }
}
