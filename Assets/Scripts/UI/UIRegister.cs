using System.Collections.Generic;
using UnityEngine;

public class UIRegister : MonoBehaviour
{
    [SerializeField] private List<UIBase> lstUI;

    void Awake()
    {
        RegistUI();
    }

    void RegistUI()
    {
        foreach (UIBase uI in lstUI)
        {
            // 게임오브젝트 이름을 key로 UIManager에 등록
            GenericSingleton<UIManager>.getInstance().AddUI(uI.gameObject.name, uI);
        }
    }
}
