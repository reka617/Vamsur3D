using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MoneyUI : UIBase
{
    TMP_Text _text;

    public override void Init()
    {
        base.Init();
        _text = transform.Find("Panel/Text").GetComponent<TMP_Text>();
    }

    void Update()
    {
        SetMoney(GenericSingleton<GameManager>.getInstance().StageGold);
    }

    void SetMoney(int m)
    {
        _text.text = m.ToString();
    }
}
