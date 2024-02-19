using UnityEngine;

// 디버그 코드

public class MainSceneTestController : MonoBehaviour
{
    WeaponSelectUI _boxInteractionUI;
    GameObject _damageUI;
    GameOverUI _gameOverUI;

    void Start()
    {
        _boxInteractionUI = GameObject.Find("WeaponSelectUI").GetComponent<WeaponSelectUI>();
        
        _damageUI = Resources.Load<GameObject>("Prefabs/UI/DamageUI");
        
        _gameOverUI = GenericSingleton<UIManager>.getInstance().GetUI<GameOverUI>();
        _gameOverUI.Init();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            _boxInteractionUI.Open();
        }
        if (Input.GetKeyDown(KeyCode.P))
        {
            _boxInteractionUI.Close();
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            GameObject instance = Instantiate(_damageUI, transform.position + Vector3.forward, Quaternion.Euler(40, 0, 0));
            instance.GetComponent<DamageEffect>().SetText(Random.Range(1, 100));
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            _gameOverUI.ShowUI();
        }
    }
}
