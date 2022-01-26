using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [Header("Mute Buttons")]
    [SerializeField] private Image soundMuteBtn;
    [SerializeField] private Image musicMuteBtn;
    [SerializeField] private Sprite soundBtnOn;
    [SerializeField] private Sprite soundBtnOff;
    [SerializeField] private Sprite musicBtnOn;
    [SerializeField] private Sprite musicBtnOff;

    private void Awake()
    {
        UpdateAudioSprites();
    }

    public void ToggleMusicAudio()
    {
        AudioManager.Instance.ToggleBGM();
        UpdateAudioSprites();
    }

    public void ToggleSoundAudio()
    {
        AudioManager.Instance.ToggleSFX();
        UpdateAudioSprites();
    }

    public void RestartGame()
    {
        SceneManager.LoadScene("Level");
    }

    public void Quit()
    {
        Application.Quit();
    }

    private void UpdateAudioSprites()
    {
        soundMuteBtn.sprite = AudioManager.Instance.isSoundOn ? soundBtnOn : soundBtnOff;
        musicMuteBtn.sprite = AudioManager.Instance.isMusicOn ? musicBtnOn : musicBtnOff;
    }
}
