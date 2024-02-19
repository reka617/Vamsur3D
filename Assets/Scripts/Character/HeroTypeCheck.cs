using Define;
using UnityEngine;
public class HeroTypeCheck: MonoBehaviour
{
    Define.Hero heroData;
    public Define.Hero _heroData { get { return heroData; } set { heroData = value; } }
    private void Awake()
    {
        HeroCheck(GenericSingleton<GameManager>.getInstance().HeroType);
        Debug.Log(_heroData);
        HeroPrefabLoad();
    }
    public void HeroCheck(HeroType inheroType)
    {
        Define.HeroType heroType = inheroType;
        Define.Hero heroData = GenericSingleton<DataManager>.getInstance().GetHeroInfo(heroType);
        _heroData = heroData;
    }
    void HeroPrefabLoad()
    {
        GameObject hero = Resources.Load<GameObject>(_heroData.prefabPath);
        Instantiate(hero);
    }
}
