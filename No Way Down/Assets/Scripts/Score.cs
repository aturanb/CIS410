using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    int score = 0;
    public TextMeshProUGUI SScoreText;
    void Update()
    {
        SScoreText.text =  score.ToString();
        //"Score:\n" +
    }

    public void getScore(int type)
    {
        if (type == 1)
        {
            score += 100;
        }
        else if (type == 2)
        {
            score += 150;
        }
        else if (type == 3)
        {
            score += 300;
        }
        else if (type == 4)
        {
            score += 200;
        }
    }

    public void addTimeScore(int time)
    {
        score= score+(300 - time) * 10;
    }

    public int checkScore()
    {
        return score;
    }
}
