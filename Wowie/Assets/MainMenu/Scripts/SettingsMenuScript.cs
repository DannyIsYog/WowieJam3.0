using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenuScript : MonoBehaviour
{
    private static readonly string BackgroundPref = "BackgroundPref";
    private static readonly string SoundEffectsPref = "SoundEffectsPref";
    [SerializeField] private Slider backgroundSlider, soundEffectsSlider;
    [SerializeField] private AudioSource soundEffects;
    private float backgroundFloat, soundEffectsFloat;
    private GameObject musicObj;
    private AudioSource music;

    void Start()
    {
        musicObj = GameObject.FindGameObjectWithTag("MainMenuMusic");
        music = musicObj.GetComponent<AudioSource>();
        backgroundFloat = PlayerPrefs.GetFloat(BackgroundPref);
        backgroundSlider.value = backgroundFloat*10;
        soundEffectsFloat = PlayerPrefs.GetFloat(SoundEffectsPref);
        soundEffectsSlider.value = soundEffectsFloat*10;
    }

    public void GoToMainMenu()
    {
        soundEffects.Play();
        SceneManager.LoadScene("Main Menu");
    }

    public void ChangeMusicVolume()
    {
        soundEffects.Play();
        PlayerPrefs.SetFloat(BackgroundPref, backgroundSlider.value/10);
        music.volume = PlayerPrefs.GetFloat(BackgroundPref);
    }

    public void ChangeSoundEffectsVolume()
    {
        soundEffects.Play();
        PlayerPrefs.SetFloat(SoundEffectsPref, soundEffectsSlider.value/10);
        soundEffects.volume = PlayerPrefs.GetFloat(SoundEffectsPref);
    }
}
