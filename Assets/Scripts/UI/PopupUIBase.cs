using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PopupUIBase : UIBase
{
    PopupUIBase _before;

    public virtual void Init(PopupUIBase before = null)
    {
        _before = before;
    }

    public void ShowUI()
    {
        if (_before != null)
        {
            _before.CloseUI();
        }

        gameObject.SetActive(true);
    }

    public void CloseUI()
    {
        gameObject.SetActive(false);

        if (_before != null)
        {
            _before.ShowUI();
        }
    }
}
