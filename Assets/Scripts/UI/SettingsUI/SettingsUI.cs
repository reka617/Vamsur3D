using UnityEngine;

public class SettingsUI : PopupUIBase
{
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            CloseUI();
        }
    }
    public void OnReturnMainMenuButton()
    {
        gameObject.SetActive(false);
    }
}
