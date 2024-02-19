using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// UIRegister ���� ���� ��ġ�� UI���� UIManager�� ���
// !!����Ϸ��� UI�� UIBase�� ��ӹ޾ƾ���!!
public class UIManager : MonoBehaviour
{
    private Dictionary<string, UIBase> _dictUI = new Dictionary<string, UIBase>();
    public bool IsStop { get { return isStop; } set { isStop = value; } } 
    bool isStop = false;

    public void AddUI(string key, UIBase uIBase)
    {
        _dictUI.Add(key, uIBase);
    }

    public T GetUI<T>() where T : UIBase
    {
        return _dictUI[typeof(T).ToString()] as T;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ESCMenuUI eSCMenuUI = GetUI<ESCMenuUI>();

            if (eSCMenuUI.gameObject.activeSelf == false)
            {
                eSCMenuUI.ShowUI();
                Time.timeScale = 0f;
                isStop = true;
            }
            else
            {
                eSCMenuUI.CloseUI();
                Time.timeScale = 1f;
                isStop = false;
            }
        }

    }

    public void Clear()
    {
        _dictUI.Clear();
    }
}
