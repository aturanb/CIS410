using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class JumpToLevel2 : MonoBehaviour
{
    public GameObject player;
    bool NextLevel = false;
    float JumpDelay = 3.5f;
    bool Ending = false;
    public TextMeshProUGUI TimeCostText;
    public TextMeshProUGUI ScoreText;
    public Timer timer;
    public Score score;

    public GameObject StopTimeText;
    public GameObject StopScoreText;
    public GameObject TimeFinal;
    public GameObject ScoreFinal;

    public GameObject dataSave;

    public static float timeScale { get; set; }

    void Start()
    {
        TimeFinal.SetActive(false);
        ScoreFinal.SetActive(false);
        dataSave = GameObject.FindGameObjectWithTag("Data");
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
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            SceneManager.LoadScene(0);// change to jump back start menu
        }
    }

    void EndLevel(bool next)
    {
        if (next)
        {
            dataSave.GetComponent<DataSave>().L2 = true;
            dataSave.GetComponent<DataSave>().L1NA = false;
            int temp = score.checkScore() + (100 - timer.getTime()) * 10;
            TimeCostText.text = "Total Time: "+timer.getTime().ToString()+"s";
            TimeFinal.SetActive(true);
            
            if (timer.getTime() >= 100)
            {
                ScoreText.text = "Score: " + score.checkScore();
            }else
            {
                ScoreText.text = "Score: " + temp;
            }
            ScoreFinal.SetActive(true);
            if (dataSave.GetComponent<DataSave>().L1Time> timer.getTime())
            {
                dataSave.GetComponent<DataSave>().L1Time = timer.getTime();
            }
            if (dataSave.GetComponent<DataSave>().L1Score < temp)
            {
                dataSave.GetComponent<DataSave>().L1Score = temp;
            }
            StopTimeText.SetActive(false);
            StopScoreText.SetActive(false);
            
            Time.timeScale = 0;
            Ending = true;
        }
    }
}
