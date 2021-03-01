using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class VictoryMenu : MonoBehaviour
{
    [SerializeField] private AudioSource clickSound;
    public void GoToMainMenu()
    {
        clickSound.Play();
        Time.timeScale = 1f;
        SceneManager.LoadScene("Main Menu");
    }

    public void Restart()
    {
        clickSound.Play();
        Time.timeScale = 1f;
        SceneManager.LoadScene("Tutorial");
    }

    public void PlayAgain()
    {
        clickSound.Play();
        Time.timeScale = 1f;
        SceneManager.LoadScene("MainLevel");
    }
}
