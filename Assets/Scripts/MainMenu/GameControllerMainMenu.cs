using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameControllerMainMenu : MonoBehaviour
{
    public GameObject Logo;
    public GameObject PlayButton;
    public GameObject QuitButton;
    public TextMeshProUGUI PlayTutorialText;
    public GameObject TutorialYesButton;
    public GameObject TutorialNoButton;

    public void PlayGame()
    {
        Logo.gameObject.SetActive(false);
        QuitButton.gameObject.SetActive(false);
        PlayButton.gameObject.SetActive(false);
        PlayTutorialText.gameObject.SetActive(true);
        TutorialYesButton.gameObject.SetActive(true);
        TutorialNoButton.gameObject.SetActive(true);
    }

    public void PlayScene(int sceneNumber)
    {
        // Load another scene
        SceneManager.LoadScene(sceneNumber);
    }

    public void QuitGame()
    {
        // Quit game
        Application.Quit();
    }
}
