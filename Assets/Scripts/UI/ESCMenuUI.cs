using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ESCMenuUI : PopupUIBase
{
    Button _resumeButton;
    Button _settingsButton;
    Button _exitButton;

    SettingsUI _settingsUI;

    public override void Init()
    {
        base.Init();

        _resumeButton = transform.Find("Panel/ResumeButton").GetComponent<Button>();
        _settingsButton = transform.Find("Panel/SettingsButton").GetComponent<Button>();
        _exitButton = transform.Find("Panel/ExitButton").GetComponent<Button>();

        _resumeButton.onClick.AddListener(OnResumeButtonClicked);
        _settingsButton.onClick.AddListener(OnSettingsButtonClicked);
        _exitButton.onClick.AddListener(OnExitButtonClicked);

        _settingsUI = GameObject.Find("UIRegister").transform.Find("SettingsUI").GetComponent<SettingsUI>();
        _settingsUI.Init(this);
    }

    void OnResumeButtonClicked()
    {
        CloseUI();
        GenericSingleton<UIManager>.getInstance().IsStop = false;
        Time.timeScale = 1f;
    }

    void OnSettingsButtonClicked()
    {
        _settingsUI.ShowUI();
        
    }

    void OnExitButtonClicked()
    {
        GenericSingleton<UIManager>.getInstance().Clear();
        GenericSingleton<GameManager>.getInstance().Clear();
        GenericSingleton<MonsterPool>.getInstance().ClearPoolObejct();
        SceneManager.LoadScene("MenuScene");
        GenericSingleton<UIManager>.getInstance().IsStop = false;
        Time.timeScale = 1f;
    }
}
