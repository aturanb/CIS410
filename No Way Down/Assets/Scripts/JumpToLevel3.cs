using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class JumpToLevel3 : MonoBehaviour
{
    public GameObject player;
    bool NextLevel = false;
    float JumpDelay = 5f;
    bool Ending = false;
    public TextMeshProUGUI TimeCostText;
    public TextMeshProUGUI ScoreText;
    public Timer timer;
    public Score score;
    public GameObject TimeCost;
    public GameObject GBScore;

    public static float timeScale { get; set; }

    void Start()
    {
        TimeCost.SetActive(false);
        GBScore.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            NextLevel = true;
        }
    }

    void Update()
    {
        if (NextLevel)
        {
            EndLevel(true);
        }
        if (Ending == true)
        {
            JumpDelay -= Time.fixedDeltaTime;
        }
        if (JumpDelay <= 0)
        {
            Time.timeScale = 1;
            SceneManager.LoadScene(4);
        }
    }

    void EndLevel(bool next)
    {
        if (next)
        {
            TimeCostText.text = "Time Cost: " + timer.getTime().ToString() + "s";
            TimeCost.SetActive(true);
            if (timer.getTime() >= 300)
            {
                ScoreText.text = "Score: " + score.checkScore();
            }
            else
            {
                int temp = score.checkScore() + (300 - timer.getTime()) * 10;
                ScoreText.text = "Score: " + temp;
            }
            GBScore.SetActive(true);
            Time.timeScale = 0;
            Ending = true;

        }
    }
}

