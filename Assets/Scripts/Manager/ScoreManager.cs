using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI score;
    public int curScore;
    float timer;
    float plusScoreTime = 0.5f;

    void Start()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<TextMeshProUGUI>();
        timer = 0;
        curScore = 0;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > plusScoreTime)
        {
            curScore += 50;
            timer = 0;
        }
        if (curScore > 5000)
            SceneManager.LoadScene("Stage1Boss");

        score.text = curScore.ToString();

    }
}
