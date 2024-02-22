using UnityEngine;
using UnityEngine.UI;

public class CharacterData : MonoBehaviour
{
    [SerializeField] Image _heroImage;
    [SerializeField] Text _characterLVTXT;
    [SerializeField] Text _liveTimeTXT;
    [SerializeField] Text _goldTXT;
    [SerializeField] Text _killsTXT;
    [SerializeField] Text _damagesTXT;
    [SerializeField] Text _vacantTXT;
    private void Start()
    {
        Text();
    }
    public void Text()
    {
        _characterLVTXT.text = "����" + GenericSingleton<GameManager>.getInstance().HeroLv;
        _liveTimeTXT.text = $"{GenericSingleton<GameManager>.getInstance().SurviveTime.ToString("F1")}" + "�� ����";
        _goldTXT.text = "ȹ����" + GenericSingleton<GameManager>.getInstance().StageGold;
        _killsTXT.text = "��ų" + GenericSingleton<GameManager>.getInstance().KillCount;
        _damagesTXT.text = "�ѵ�����" + GenericSingleton<GameManager>.getInstance().TotalDmg;
        if (GenericSingleton<GameManager>.getInstance().HeroType == Define.HeroType.Wizard)
        {
            _heroImage.sprite = Resources.Load("Art/Textures/CharacterThumbnails/WizardThumb", typeof(Sprite)) as Sprite;
        }
        if (GenericSingleton<GameManager>.getInstance().HeroType == Define.HeroType.SwordHero)
        {
            _heroImage.sprite = Resources.Load("Art/Textures/CharacterThumbnails/SwordHeroThumb", typeof(Sprite)) as Sprite;
        }
    }
}
