using UnityEngine;

public interface ISoundService
{
    void PlaySound(AudioClip clip);

    void PlayMusic(AudioClip clip, bool loop = true);
    void StopMusic();
    void PauseMusic();
    void ResumeMusic();

    float SoundVolume { get; set; }
    float MusicVolume { get; set; }
}
