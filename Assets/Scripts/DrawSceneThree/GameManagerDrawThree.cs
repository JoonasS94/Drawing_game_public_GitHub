using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameManagerDrawThree : MonoBehaviour
{

    public GameObject go1;
    public GameObject go2;

    private GameObject Do;

    // luku m‰‰ritet‰‰n per kentt‰
    // muista myˆs unity editor vaihtaa sama luku
    public int lasku = 133;
    // 100 / mesh collidereiden maara
    // muista myˆs unity editor vaihtaa sama luku
    public float suhdeluku = 0.67567f;

    public float jakolasku;
    public float sataMuunnos;

    public TextMeshProUGUI StartTextThree;
    public TextMeshProUGUI StartTextThreeGo;
    public TextMeshProUGUI InkLeftText;
    public TextMeshProUGUI ComparingResultsText;
    public TextMeshProUGUI FinalScoreText;

    public TextMeshProUGUI CheerText91_100;
    public TextMeshProUGUI CheerText81_90;
    public TextMeshProUGUI CheerText71_80;
    public TextMeshProUGUI CheerText61_70;
    public TextMeshProUGUI CheerText51_60;
    public TextMeshProUGUI CheerText41_50;
    public TextMeshProUGUI CheerText31_40;
    public TextMeshProUGUI CheerText21_30;
    public TextMeshProUGUI CheerText11_20;
    public TextMeshProUGUI CheerText0_10;

    public GameObject joyStick;

    public GameObject NextPictureButton;
    public GameObject StopDrawing;
    public GameObject ArrowPartOne;
    public GameObject ArrowPartTwo;

    public float twoDec;
    public int cubeScore;
    private CubeScoring cubeScript;
    private bool stillDrawing = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(StartSet());
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float dist = Vector3.Distance(go1.transform.position, go2.transform.position);

        if (dist > 0.15f && stillDrawing == true)
        { 
            //Debug.Log("Distance grown, I should move now");
            go2.transform.position = new Vector3(go1.transform.position.x, -0.0035f, go1.transform.position.z);
            lasku = (lasku - 1);
            UpdateInkLeft(lasku);
        }

        if (lasku == 0 && stillDrawing == true)
        {
            stillDrawing = false;
            StopDrawing.gameObject.SetActive(false);
            go1.GetComponent<PlayerController>().playerSpeed = 0f;

            // final score
            cubeScript = go2.GetComponent<CubeScoring>();
            cubeScore = cubeScript.score;

            StartCoroutine(ShowResults());
            StartCoroutine(NextButton());
        }

        // Turn ink left text to red when only about 10 % left
        if (lasku == 13 && stillDrawing == true)
        {
            InkLeftText.color = new Color(1.0f, 0f, 0f, 1.0f);
        }

    }

    public void UpdateInkLeft(float inkLeft)
    {
        twoDec = Mathf.RoundToInt(inkLeft);
        // luku m‰‰ritet‰‰n per kentt‰ - 1
        jakolasku = (inkLeft / 132 * 100);
        twoDec = Mathf.RoundToInt(jakolasku);
        InkLeftText.text = "Ink left: " + twoDec + " %";
    }

    IEnumerator StartSet()
    {
        yield return new WaitForSeconds(3);
        StartTextThree.gameObject.SetActive(false);

        Do = GameObject.Find("DrawThree");
        MeshRenderer[] meshRenderers = Do.GetComponentsInChildren<MeshRenderer>();

        foreach (MeshRenderer childRenderMeshes in meshRenderers)
        {
            childRenderMeshes.enabled = true;
        }


        yield return new WaitForSeconds(9);
        go1.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);

        foreach (MeshRenderer childRenderMeshes in meshRenderers)
        {
            childRenderMeshes.enabled = false;
        }

        InkLeftText.gameObject.SetActive(true);
        joyStick.gameObject.SetActive(true);
        ArrowPartOne.gameObject.SetActive(true);
        ArrowPartTwo.gameObject.SetActive(true);
        StartTextThreeGo.gameObject.SetActive(true);
        yield return new WaitForSeconds(1);
        ArrowPartOne.gameObject.SetActive(false);
        ArrowPartTwo.gameObject.SetActive(false);
        StartTextThreeGo.gameObject.SetActive(false);
        yield return new WaitForSeconds(5);
        StopDrawing.gameObject.SetActive(true);
    }

    public void stopDrawing()
    {
        joyStick.gameObject.SetActive(false);
        StopDrawing.gameObject.SetActive(false);
        lasku = 0;
    }


    IEnumerator ShowResults()
    {
        yield return new WaitForSeconds(1);

        InkLeftText.gameObject.SetActive(false);

        ComparingResultsText.gameObject.SetActive(true);

        Do = GameObject.Find("DrawThree");
        MeshRenderer[] meshRenderers = Do.GetComponentsInChildren<MeshRenderer>();

        foreach (MeshRenderer childRenderMeshes in meshRenderers)
        {
            childRenderMeshes.enabled = true;
        }

        yield return new WaitForSeconds(5);

        ComparingResultsText.gameObject.SetActive(false);

        sataMuunnos = (cubeScore * suhdeluku);
        twoDec = Mathf.RoundToInt(sataMuunnos);
        GameObject.Find("DrawThreeScore").GetComponent<DrawThreeScore>().drawThreeScore = twoDec;



        // Ratings

        // 91 - 100 score cheer
        if (twoDec >= 91)
        {
            FinalScoreText.text = "Score:" + twoDec;
            FinalScoreText.gameObject.SetActive(true);

            yield return new WaitForSeconds(1);
            CheerText91_100.gameObject.SetActive(true);
        }

        // 81 - 90 score cheer
        if (twoDec >= 81 && twoDec <= 90)
        {
            FinalScoreText.text = "Score: " + twoDec;
            FinalScoreText.gameObject.SetActive(true);

            yield return new WaitForSeconds(1);
            CheerText81_90.gameObject.SetActive(true);
        }

        // 71 - 80 score cheer
        if (twoDec >= 71 && twoDec <= 80)
        {
            FinalScoreText.text = "Score: " + twoDec;
            FinalScoreText.gameObject.SetActive(true);

            yield return new WaitForSeconds(1);
            CheerText71_80.gameObject.SetActive(true);
        }

        // 61 - 70 score cheer
        if (twoDec >= 61 && twoDec <= 70)
        {
            FinalScoreText.text = "Score: " + twoDec;
            FinalScoreText.gameObject.SetActive(true);

            yield return new WaitForSeconds(1);
            CheerText61_70.gameObject.SetActive(true);
        }

        // 50 - 60 score cheer
        if (twoDec >= 50 && twoDec <= 60)
        {
            FinalScoreText.text = "Score: " + twoDec;
            FinalScoreText.gameObject.SetActive(true);

            yield return new WaitForSeconds(1);
            CheerText51_60.gameObject.SetActive(true);
        }

        // 41 - 49 score cheer
        if (twoDec >= 41 && twoDec <= 49)
        {
            FinalScoreText.text = "Score: " + twoDec;
            FinalScoreText.gameObject.SetActive(true);

            yield return new WaitForSeconds(1);
            CheerText41_50.gameObject.SetActive(true);
        }

        // 31 - 40 score cheer
        if (twoDec >= 31 && twoDec <= 40)
        {
            FinalScoreText.text = "Score: " + twoDec;
            FinalScoreText.gameObject.SetActive(true);

            yield return new WaitForSeconds(1);
            CheerText31_40.gameObject.SetActive(true);
        }

        // 21 - 30 score cheer
        if (twoDec >= 21 && twoDec <= 30)
        {
            FinalScoreText.text = "Score: " + twoDec;
            FinalScoreText.gameObject.SetActive(true);

            yield return new WaitForSeconds(1);
            CheerText21_30.gameObject.SetActive(true);
        }

        // 11 - 20 score cheer
        if (twoDec >= 11 && twoDec <= 20)
        {
            FinalScoreText.text = "Score: " + twoDec;
            FinalScoreText.gameObject.SetActive(true);

            yield return new WaitForSeconds(1);
            CheerText11_20.gameObject.SetActive(true);
        }

        // 0 - 10 score cheer
        if (twoDec <= 10)
        {
            FinalScoreText.text = "Score: " + twoDec;
            FinalScoreText.gameObject.SetActive(true);

            yield return new WaitForSeconds(1);
            CheerText0_10.gameObject.SetActive(true);
        }

    }

    IEnumerator NextButton()
    {
        yield return new WaitForSeconds(9);
        NextPictureButton.gameObject.SetActive(true);
    }

}
