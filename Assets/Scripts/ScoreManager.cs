using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScoreManager : MonoBehaviour
{
    public TextMeshProUGUI score;
    public int curScore;
    float timer;
    float plusScoreTime=0.5f;

    void Start()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<TextMeshProUGUI>();
        timer = 0;
        curScore = 99999;
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (timer > plusScoreTime)
        {
            curScore += 0;
            timer = 0;
        }

        score.text = curScore.ToString();

    }
}
