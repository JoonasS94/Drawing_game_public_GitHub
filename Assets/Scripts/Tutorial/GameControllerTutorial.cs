using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameControllerTutorial : MonoBehaviour
{
    public GameObject tutorialObject;
    public GameObject ContinueButton1;
    public GameObject ContinueButton2;
    public GameObject ContinueButton3;
    public GameObject ArrowPartOne;
    public GameObject ArrowPartTwo;
    public GameObject PlayerObject;
    public GameObject JoyStick;
    public GameObject WhiteWall;


    public TextMeshProUGUI TutorialText1;
    public TextMeshProUGUI TutorialText2;
    public TextMeshProUGUI TutorialText3;
    public TextMeshProUGUI TutorialText4;
    public TextMeshProUGUI TutorialText5;
    public TextMeshProUGUI TutorialText6;

    private bool LoadingNextLevel = true;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(TutorialOneTimer());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator TutorialOneTimer()
    {
        yield return new WaitForSeconds(4);
        ContinueButton1.gameObject.SetActive(true);
    }

    public void TutorialButtonOne()
    {
        tutorialObject.gameObject.SetActive(false);
        ContinueButton1.gameObject.SetActive(false);
        TutorialText1.gameObject.SetActive(false);
        StartCoroutine(TutorialButtonOneTimer());
    }

    IEnumerator TutorialButtonOneTimer()
    {
        TutorialText2.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        ContinueButton2.gameObject.SetActive(true);

    }

    public void TutorialButtonTwo()
    {
        ContinueButton2.gameObject.SetActive(false);
        TutorialText2.gameObject.SetActive(false);
        StartCoroutine(TutorialButtonTwoTimer());
    }

    IEnumerator TutorialButtonTwoTimer()
    {
        TutorialText3.gameObject.SetActive(true);
        ArrowPartOne.gameObject.SetActive(true);
        ArrowPartTwo.gameObject.SetActive(true);
        PlayerObject.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        ContinueButton3.gameObject.SetActive(true);

    }

    public void TutorialButtonThree()
    {
        ContinueButton3.gameObject.SetActive(false);
        TutorialText3.gameObject.SetActive(false);
        ArrowPartOne.gameObject.SetActive(false);
        ArrowPartTwo.gameObject.SetActive(false);
        StartCoroutine(TutorialButtonThreeTimer());
    }

    IEnumerator TutorialButtonThreeTimer()
    {
        TutorialText4.gameObject.SetActive(true);
        JoyStick.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        TutorialText5.gameObject.SetActive(true);
    }

    public void TutorialFinishTimer()
    {
        StartCoroutine(TutorialFinish());
    }

    public IEnumerator TutorialFinish()
    {
        TutorialText4.gameObject.SetActive(false);
        JoyStick.gameObject.SetActive(false);
        TutorialText5.gameObject.SetActive(false);
        PlayerObject.gameObject.SetActive(false);
        WhiteWall.gameObject.SetActive(false);
        TutorialText6.gameObject.SetActive(true);
        yield return new WaitForSeconds(5);

        if (LoadingNextLevel == true)
        {
            SceneManager.LoadScene(1);
        }
        LoadingNextLevel = false;
    }
}
