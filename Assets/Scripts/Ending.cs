using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Ending : MonoBehaviour
{
    public ScoreManager scoreManager;
    public TextMeshProUGUI EndingScoreResult;
    public GameObject[] GameUI;

    public int FinalScore;
    public int CurScore = 0;

    private void Start()
    {
        scoreManager = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager>();
        EndingScoreResult = GameObject.FindGameObjectWithTag("EndingScore").GetComponent<TextMeshProUGUI>();
        //StartCoroutine("End");
    }

    IEnumerator End()
    {
        foreach (GameObject gameObject in GameUI)
        {
            gameObject.SetActive(true);
            yield return null;
        }


        Time.timeScale = .1f;

        LeanTween.value(GameUI[1], new Color(1, 1, 1, 0), new Color(1, 1, 1, 1), .1f);
        LeanTween.value(GameUI[3], new Color(0, 0, 0, 0), new Color(0, 0, 0, .4f), .1f);

        LeanTween.moveY(GameUI[2], 0, .2f);

        yield return new WaitForSeconds(.2f);

        FinalScore = scoreManager.curScore;

        while (FinalScore > CurScore)
        {

            if (FinalScore - CurScore > 10000)
                CurScore += 100;
            if (FinalScore - CurScore > 1000)
                CurScore += 10;
            CurScore += 1;

            EndingScoreResult.text = CurScore.ToString();

            yield return null;
        }

    }
}
