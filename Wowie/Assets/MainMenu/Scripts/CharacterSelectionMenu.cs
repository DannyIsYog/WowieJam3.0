using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelectionMenu : MonoBehaviour
{
    [SerializeField] private AudioSource clickSound;
    private static readonly string SoundEffectsPref = "SoundEffectsPref";
    private GameObject music;

    public GameObject[] characters;
    public int selectedCharacter = 0;

    void Start()
    {
        clickSound.volume = PlayerPrefs.GetFloat(SoundEffectsPref);
        music = GameObject.FindGameObjectWithTag("MainMenuMusic");
    }

    // Update is called once per frame
    public void GoToMainMenu()
    {
        clickSound.Play();
        SceneManager.LoadScene("Main Menu");
    }

    public void NextCharacter()
    {
        clickSound.Play();
        characters[selectedCharacter].SetActive(false);
        selectedCharacter = (selectedCharacter + 1) % characters.Length;
        characters[selectedCharacter].SetActive(true);
    }

    public void PreviousCharacter()
    {
        clickSound.Play();
        characters[selectedCharacter].SetActive(false);
        selectedCharacter--;
        
        if (selectedCharacter < 0) selectedCharacter += characters.Length;

        characters[selectedCharacter].SetActive(true);
    }

    public void StartGame()
    {
        clickSound.Play();
        PlayerPrefs.SetInt("selectedCharater", selectedCharacter);
        Destroy(music);
        SceneManager.LoadScene("Fábio");
    }
}
