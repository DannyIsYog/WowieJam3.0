using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    private GameObject music;
    [SerializeField] private AudioSource clickSoundEffect;
    [SerializeField] private GameObject dontDestroyScript;

    public void Start()
    {
        music = GameObject.FindGameObjectWithTag("MainMenuMusic");
    }

    public void PlayGame()
    {
        clickSoundEffect.Play();
        SceneManager.LoadScene("CharacterSelection");
    }

    public void GoToSettingsMenu()
    {
        clickSoundEffect.Play();
        SceneManager.LoadScene("Settings");
    }

    public void GoToCredits()
    {
        clickSoundEffect.Play();
        SceneManager.LoadScene("Credits");
    }

    public void GoToTutorial()
    {
        Destroy(music);
        clickSoundEffect.Play();
        SceneManager.LoadScene("Tutorial");
    }

    public void QuitGame()
    {
        clickSoundEffect.Play();
        Application.Quit();
    }
}
