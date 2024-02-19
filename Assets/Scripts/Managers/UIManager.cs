using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

// UIRegister 통해 씬에 배치한 UI들을 UIManager에 등록
// !!등록하려는 UI는 UIBase를 상속받아야함!!
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
