using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPBarUI : UIBase
{
    float maxHP = 0;
    Hero _hero;
    GameObject _target;
    Vector3 _offset;
    
    RectTransform _foreground;

    public override void Init()
    {
        _hero = GenericSingleton<GameManager>.getInstance().Player.GetComponent<Hero>();

        _target = GameObject.FindGameObjectWithTag("Player");
        _offset = new Vector3(0, 0.2f, -1f);

        transform.rotation = Camera.main.transform.rotation;

        _foreground = transform.Find("Panel/Foreground").GetComponent<RectTransform>();
        maxHP = _hero._hP;
    }

    void Update()
    {
        transform.position = _target.transform.position + _offset;
        ResizeBar(_hero._hP / maxHP);
    }

    void ResizeBar(float percent)
    {
        Debug.Log(_foreground);
        _foreground.localScale = new Vector3(percent, 1f, 0f);
    }
}
