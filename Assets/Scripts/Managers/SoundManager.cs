using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public class SoundManager : MonoBehaviour, ISoundService
{
    public static SoundManager Instance { get; private set; }
    
    [Header("Music")]
    [SerializeField] private AudioClip _bgmClip;

    [SerializeField] private AudioSource _soundSource;
    [SerializeField] private AudioSource _musicSource;

    [SerializeField, Range(0f, 1f)] private float _soundVolume = 1f;
    [SerializeField, Range(0f, 1f)] private float _musicVolume = 1f;

    [Header("SFX")]
    [SerializeField] private AudioClip _hitClip;
    [SerializeField] private AudioClip[] _weaponClips; // WeaponType enum 순서에 맞게 인스펙터 배열

    private void Awake()
    {
        if (Instance != null) { Destroy(gameObject); return; }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public float SoundVolume
    {
        get => _soundVolume;
        set { _soundVolume = Mathf.Clamp01(value); _soundSource.volume = _soundVolume; }
    }

    public float MusicVolume
    {
        get => _musicVolume;
        set { _musicVolume = Mathf.Clamp01(value); _musicSource.volume = _musicVolume; }
    }

    public void PlaySound(AudioClip clip)
    {
        if (clip == null) return;
        _soundSource.PlayOneShot(clip, _soundVolume);
    }

    public void PlayHitSound()                              => PlaySound(_hitClip);
    public void PlayWeaponSound(Define.WeaponType type)     => PlaySound(GetWeaponClip(type));

    private AudioClip GetWeaponClip(Define.WeaponType type)
    {
        int index = (int)type;
        if (index < 0 || index >= _weaponClips.Length) return null;
        return _weaponClips[index];
    }

    public void PlayMusic(AudioClip clip, bool loop = true)
    {
        if (clip == null) return;
        if (_musicSource.clip == clip && _musicSource.isPlaying) return;
        _musicSource.clip = clip;
        _musicSource.loop = loop;
        _musicSource.volume = _musicVolume;
        _musicSource.Play();
    }

    public void StopMusic()   => _musicSource.Stop();
    public void PauseMusic()  => _musicSource.Pause();
    public void ResumeMusic() => _musicSource.UnPause();
    public void PlayBGM() => PlayMusic(_bgmClip);
    public void StopSound() => _soundSource.Stop();
}