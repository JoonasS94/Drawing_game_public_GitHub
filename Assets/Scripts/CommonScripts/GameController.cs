using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{

    public void PlayScene(int sceneNumber)
    {
        // Load another scene
        SceneManager.LoadScene(sceneNumber);
    }
}
