using UnityEngine;
using UnityEngine.SceneManagement;
public class LoadMenuScene : MonoBehaviour
{
    [SerializeField] WeaponData _weaponData;
    [SerializeField] GameObject _butten;
    void Start()
    {
        _weaponData.StartPanel();
        Debug.Log("OpTion");
    }
    public void OnButtonPress()
    {
        Debug.Log("��ưȰ��ȭ");
        GenericSingleton<GameManager>.getInstance().Clear();
        GenericSingleton<MonsterPool>.getInstance().ClearPoolObejct();
        SceneManager.LoadScene("MenuScene"); //�κ������ 
    }
}
