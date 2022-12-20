using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerResults : MonoBehaviour
{

    public TextMeshProUGUI LetsCountFinalScore;
    public TextMeshProUGUI ScoreOne;
    public TextMeshProUGUI ScoreTwo;
    public TextMeshProUGUI ScoreThree;
    public TextMeshProUGUI ScoreFour;
    public TextMeshProUGUI ThanksPlaying;
    public TextMeshProUGUI PlusOne;
    public TextMeshProUGUI PlusTwo;
    public TextMeshProUGUI PlusThree;
    public TextMeshProUGUI Equal;
    public TextMeshProUGUI finalResult;

    public GameObject starOne;
    public GameObject starTwo;
    public GameObject starThree;
    public GameObject starFour;
    public GameObject starFive;

    public GameObject MenuButton;

    public float firstScore;
    public float secondScore;
    public float thirdScore;
    public float fourthScore;
    public float finalPoints;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartSet());
    }

    // Update is called once per frame
    void FixedUpdate()
    {

    }

    IEnumerator StartSet()
    {
        //StartTextTwo.gameObject.SetActive(false);
        firstScore = GameObject.Find("DrawOneScore").GetComponent<DrawOneScore>().drawOneScore;
        secondScore = GameObject.Find("DrawTwoScore").GetComponent<DrawTwoScore>().drawTwoScore;
        thirdScore = GameObject.Find("DrawThreeScore").GetComponent<DrawThreeScore>().drawThreeScore;
        fourthScore = GameObject.Find("DrawFourScore").GetComponent<DrawFourScore>().drawFourScore;

        finalPoints = firstScore + secondScore + thirdScore + fourthScore;

        Destroy(GameObject.Find("DrawOneScore"));
        Destroy(GameObject.Find("DrawTwoScore"));
        Destroy(GameObject.Find("DrawThreeScore"));
        Destroy(GameObject.Find("DrawFourScore"));

        yield return new WaitForSeconds(2.5f);
        ScoreOne.text = "" + firstScore;
        ScoreOne.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        PlusOne.gameObject.SetActive(true);
        ScoreTwo.text = "" + secondScore;
        ScoreTwo.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        PlusTwo.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        ScoreThree.text = "" + thirdScore;
        ScoreThree.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        PlusThree.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        ScoreFour.text = "" + fourthScore;
        ScoreFour.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        Equal.gameObject.SetActive(true);
        yield return new WaitForSeconds(3);
        finalResult.text = "" + finalPoints;
        finalResult.gameObject.SetActive(true);

        yield return new WaitForSeconds(2.5f);
        LetsCountFinalScore.gameObject.SetActive(false);
        ScoreOne.gameObject.SetActive(false);
        ScoreTwo.gameObject.SetActive(false);
        ScoreThree.gameObject.SetActive(false);
        ScoreFour.gameObject.SetActive(false);
        PlusOne.gameObject.SetActive(false);
        PlusTwo.gameObject.SetActive(false);
        PlusThree.gameObject.SetActive(false);
        Equal.gameObject.SetActive(false);

        if (finalPoints <= 99)
        {
            starThree.gameObject.SetActive(true);
        }

        if (finalPoints >= 100 && finalPoints <= 199)
        {
            starTwo.gameObject.SetActive(true);
            starFour.gameObject.SetActive(true);
        }

        if (finalPoints >= 200 && finalPoints <= 280)
        {
            starTwo.gameObject.SetActive(true);
            starThree.gameObject.SetActive(true);
            starFour.gameObject.SetActive(true);
        }

        if (finalPoints >= 281 && finalPoints <= 360)
        {
            starOne.gameObject.SetActive(true);
            starTwo.gameObject.SetActive(true);
            starFour.gameObject.SetActive(true);
            starFive.gameObject.SetActive(true);
        }

        if (finalPoints >= 360)
        {
            starOne.gameObject.SetActive(true);
            starTwo.gameObject.SetActive(true);
            starThree.gameObject.SetActive(true);
            starFour.gameObject.SetActive(true);
            starFive.gameObject.SetActive(true);
        }

        ThanksPlaying.gameObject.SetActive(true);
        yield return new WaitForSeconds(2.5f);
        MenuButton.gameObject.SetActive(true);
    }

}
