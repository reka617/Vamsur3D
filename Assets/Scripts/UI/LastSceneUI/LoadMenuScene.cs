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
        Debug.Log("버튼활성화");
        GenericSingleton<GameManager>.getInstance().Clear();
        GenericSingleton<MonsterPool>.getInstance().ClearPoolObejct();
        SceneManager.LoadScene("MenuScene"); //로비씬으로 
    }
}
