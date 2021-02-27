using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class TutorialMenu : MonoBehaviour
{
    [SerializeField] private AudioSource clickSound;
    private static readonly string SoundEffectsPref = "SoundEffectsPref";
    void Start()
    {
        clickSound.volume = PlayerPrefs.GetFloat(SoundEffectsPref);
    }

    // Update is called once per frame
    public void GoToMainMenu()
    {
        clickSound.Play();
        SceneManager.LoadScene("Main Menu");

    }
}
