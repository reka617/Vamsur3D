using UnityEngine;

public class PlayerExpBarUI : UIBase
{
    float maxExp;
    float curExp;

    RectTransform _foreground;

    public override void Init()
    {
        _foreground = transform.Find("Panel/Foreground").GetComponent<RectTransform>();
    }

    void Update()
    {
        curExp = GenericSingleton<GameManager>.getInstance().HeroExp - (GenericSingleton<GameManager>.getInstance().HeroLv - 1) * 100f;
        maxExp = 100f;
        float percent = curExp / maxExp;
        ResizeBar(percent);
    }

    void ResizeBar(float percent)
    {
        if (percent < 0f)
            percent = 0f;

        _foreground.localScale = new Vector3(percent, 1f, 0f);
    }
}
