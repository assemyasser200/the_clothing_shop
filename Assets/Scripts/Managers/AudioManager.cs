using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct AudioItem
{
    public string id;
    public AudioClip clip;
}

public class AudioManager : Singleton<AudioManager>
{
    [Header("Audio Sources")]
    [SerializeField] private AudioSource bgmSource;
    [SerializeField] private AudioSource sfxSource;

    [Header("BGM Clips")]
    [SerializeField] private List<AudioItem> musicClips;

    [Header("SFX Clips")]
    [SerializeField] private List<AudioItem> soundClips;

    private bool isMusicOn;
    private bool isSoundOn;

    protected override void OnSingletonAwake()
    {
        isMusicOn = PlayerPrefs.GetInt("Music_On", 1) == 1 ? true : false;
        isSoundOn = PlayerPrefs.GetInt("Sound_On", 1) == 1 ? true : false;
        UpdateSourcesSettings();
    }

    private AudioItem GetAudioItem(string key, List<AudioItem> audioItems)
    {
        return audioItems.Find(item => item.id.Equals(key));
    }

    private void UpdateSourcesSettings()
    {
        bgmSource.mute = !isMusicOn;
        sfxSource.mute = !isSoundOn;
    }

    public void ChangeBGM(string musicId)
    {
        AudioItem selectedItem = GetAudioItem(musicId, musicClips);
        bgmSource.clip = selectedItem.clip;
    }

    public void PlaySoundEffect(string soundId)
    {
        AudioItem selectedItem = GetAudioItem(soundId, soundClips);
        sfxSource.PlayOneShot(selectedItem.clip);
    }

    public void ToggleBGM()
    {
        isMusicOn = !isMusicOn;
        PlayerPrefs.SetInt("Music_On", isMusicOn ? 1 : 0);
        UpdateSourcesSettings();
    }

    public void ToggleSFX()
    {
        isSoundOn = !isSoundOn;
        PlayerPrefs.SetInt("Sound_On", isSoundOn ? 1 : 0);
        UpdateSourcesSettings();
    }
}
