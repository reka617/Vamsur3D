using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class KillCountUI : UIBase
{
    TMP_Text _text;

    public override void Init()
    {
        base.Init();

        _text = transform.Find("Panel/Text").GetComponent<TMP_Text>();

    }

    void Update()
    {
        SetKillCount(GenericSingleton<GameManager>.getInstance().KillCount);
    }

    void SetKillCount(int kc)
    {
        _text.text = kc.ToString();
    }
}
