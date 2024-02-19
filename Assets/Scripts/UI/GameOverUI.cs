using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverUI : UIBase
{
    // Todo
    // Manager���� GameEnd �÷��� ����� �ش� �÷��׿� �°� �ε��ϱ�
    bool isGameEnd = false;

    Button _quitButton;

    float _fadeDuration = 0.25f;
    float _fadeTImer = 0f;

    Image[] _images;
    float[] _imgAlphas;

    public override void Init()
    {
        _quitButton = GetComponentInChildren<Button>();
        _quitButton.onClick.AddListener(() => { OnQuitButtonClicked(); });

        _images = GetComponentsInChildren<Image>();
        _imgAlphas = new float[_images.Length];
        for (int i = 0; i < _images.Length; i++)
        {
            _imgAlphas[i] = _images[i].color.a;
        }
    }

    public void ShowUI()
    {
        gameObject.SetActive(true);
        StartCoroutine(FadeUI());
    }

    IEnumerator FadeUI()
    {
        while (_fadeTImer < _fadeDuration)
        {
            _fadeTImer += Time.deltaTime;

            for (int i = 0; i < _images.Length; i++)
            {
                // �⺻ ���İ��� _fadeTImer�̿��ؼ� ������ �� �����ֱ�
                Color c = _images[i].color;
                _images[i].color = new Color(c.r, c.g, c.b, _imgAlphas[i] * (_fadeTImer / _fadeDuration));
            }

            yield return new WaitForEndOfFrame();
        }
    }

    void OnQuitButtonClicked()
    {
        SceneManager.LoadScene("Lastscene");
    }
}
