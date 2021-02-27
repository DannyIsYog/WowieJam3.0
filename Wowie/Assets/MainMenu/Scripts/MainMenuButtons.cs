using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenuButtons : MonoBehaviour
{
    private GameObject music;
    [SerializeField] private AudioSource clickSoundEffect;
    public void PlayGame()
    {
        clickSoundEffect.Play();
        music = GameObject.FindGameObjectWithTag("MainMenuMusic");
        //Destroy(music);
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
        clickSoundEffect.Play();
        SceneManager.LoadScene("Tutorial");
    }

    public void QuitGame()
    {
        clickSoundEffect.Play();
        Application.Quit();
    }
}
