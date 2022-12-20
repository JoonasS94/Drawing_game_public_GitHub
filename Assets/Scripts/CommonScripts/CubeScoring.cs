using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeScoring : MonoBehaviour
{
    public int score;
    private GameControllerTutorial gameControllerTutorial;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("DrawArea"))
        {
            other.GetComponent<MeshCollider>().enabled = false;
            score += 1;
        }

        if (other.CompareTag("Finish"))
        {
            gameControllerTutorial = GameObject.Find("GameControllerTutorial").GetComponent<GameControllerTutorial>();
            Destroy(GameObject.Find("FinishTutorialArea"));
            gameControllerTutorial.TutorialFinishTimer();
        }
    }
}
