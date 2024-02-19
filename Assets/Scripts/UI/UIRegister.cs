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
            // ���ӿ�����Ʈ �̸��� key�� UIManager�� ���
            GenericSingleton<UIManager>.getInstance().AddUI(uI.gameObject.name, uI);
        }
    }
}
