using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Stage1Score : MonoBehaviour
{
    public TextMeshProUGUI score;
    public int curScore;
    public int bossKillNum=0;

    
    void Start()
    {
        score = GameObject.FindGameObjectWithTag("Score").GetComponent<TextMeshProUGUI>();
        curScore = 5000;
    }

    
    void Update()
    {
        score.text = curScore.ToString();
        if (bossKillNum == 15)
        {
            curScore += 500;
            //���⿡ ���� Ŭ���� ���� ��
        }
    }
}
