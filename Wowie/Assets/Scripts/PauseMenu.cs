using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    private static readonly string BackgroundPref = "BackgroundPref";
    private static readonly string SoundEffectsPref = "SoundEffectsPref";
    [SerializeField] private Slider backgroundSlider, soundEffectsSlider;
    [SerializeField] private AudioSource backgroundMusic;
    [SerializeField] private AudioSource clickSound;
    [SerializeField] private AudioSource[] soundEffects;
    [SerializeField] GameObject pauseMenuUI;
    private float backgroundFloat, soundEffectsFloat;
    public static bool GameIsPaused = false;

    void Start()
    {
        backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
        backgroundSlider.value = backgroundFloat * 10;
        soundEffectsFloat = PlayerPrefs.GetFloat(SoundEffectsPref);
        soundEffectsSlider.value = soundEffectsFloat * 10;
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                clickSound.Play();
                Resume();
            } else
            {
                clickSound.Play();
                Pause();
            }
        }
    }

    public void Resume()
    {
        clickSound.Play();
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }

    public void Pause()
    {
        clickSound.Play();
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }

    public void GoToMainMenu()
    {
        clickSound.Play();
        Time.timeScale = 1f;
        GameIsPaused = false;
        SceneManager.LoadScene("Main Menu");
    }

    public void ChangeMusicVolume()
    {
        clickSound.Play();
        PlayerPrefs.SetFloat(BackgroundPref, backgroundSlider.value / 10);
        backgroundMusic.volume = PlayerPrefs.GetFloat(BackgroundPref);
    }

    public void ChangeSoundEffectsVolume()
    {
        clickSound.Play();
        PlayerPrefs.SetFloat(SoundEffectsPref, soundEffectsSlider.value / 10);

        for (int i = 0; i < soundEffects.Length; i++)
        {
            soundEffects[i].volume = PlayerPrefs.GetFloat(SoundEffectsPref);
        }
    }
}
