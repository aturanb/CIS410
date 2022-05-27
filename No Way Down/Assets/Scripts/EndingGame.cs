using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndingGame : MonoBehaviour
{
    public GameObject player;
    bool EndGame = false;
    public GameObject winTextObject;
    public static float timeScale { get; set; }
    bool Ending = false;
    float EndDelay = 5f;
    public TextMeshProUGUI TimeCostText;
    public TextMeshProUGUI ScoreText;
    public Score score;
    public Timer timer;
    public GameObject TimeCost;
    public GameObject GBScore;

    void Start()
    {
        winTextObject.SetActive(false);
        TimeCost.SetActive(false);
        GBScore.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            EndGame = true;
        }
    }

    void Update()
    {
        if (EndGame)
        {
            EndLevel(true);
        }
        if (Ending == true)
        {
            EndDelay -= Time.fixedDeltaTime;
        }
        if (EndDelay <= 0)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            Time.timeScale = 1;
            SceneManager.LoadScene(0);
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
            winTextObject.SetActive(true);
            Time.timeScale = 0;
            Ending = true;
        }
    }
}
