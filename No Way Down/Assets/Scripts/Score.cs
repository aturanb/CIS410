using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    int score = 0;

    void Update()
    {
        print(checkScore());
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



    public int checkScore()
    {
        return score;
    }
}
