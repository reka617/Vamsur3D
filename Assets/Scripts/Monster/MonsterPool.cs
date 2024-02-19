using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterPool : MonoBehaviour
{
    List<GameObject> _lstObj = new List<GameObject>();
    GameObject[] _monObjs = null;

    public List<GameObject> LstObj { get { return _lstObj; } }

    void Init()
    {
        if (_monObjs != null) return;
        _monObjs = new GameObject[(int)Define.MonsterType.Max];
        for(int i=1; i < (int)Define.MonsterType.Max; i++)
        {
            //리소스 로드
            _monObjs[i] = Resources.Load("Prefabs/Monster/" + (Define.MonsterType)i) as GameObject;
        }
    }

    public GameObject GetPoolObject(Define.MonsterType mType)
    {

        foreach (GameObject obj in _lstObj)
        {
            if (obj.activeSelf == false && obj.GetComponent<Monster>().sendMonsterType == mType)
            {
                return obj;
            }
        }
        Init();
        GameObject temp = Instantiate(_monObjs[(int)mType]);
        _lstObj.Add(temp);
        return temp;

    }

    public void ClearPoolObejct()
    {
        foreach(GameObject obj in _lstObj)
        {
            Destroy(obj);
        }
        _lstObj.Clear();
    }
}
