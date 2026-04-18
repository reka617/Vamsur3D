using UnityEngine;
using UnityEngine.UI;

public class SettingSound : MonoBehaviour
{
    public enum VolumeType { Sound, Music }

    [SerializeField] private VolumeType _volumeType;

    private Slider _slider;

    private void Start()
    {
        _slider = transform.Find("Slider").GetComponent<Slider>();

        _slider.value = _volumeType == VolumeType.Sound
            ? SoundManager.Instance.SoundVolume
            : SoundManager.Instance.MusicVolume;

        _slider.onValueChanged.AddListener(OnValueChanged);
    }

    private void OnValueChanged(float value)
    {
        if (_volumeType == VolumeType.Sound)
            SoundManager.Instance.SoundVolume = value;
        else
            SoundManager.Instance.MusicVolume = value;
    }
}