using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DataSave : MonoBehaviour
{
    public bool L2 = false;
    public bool L3 = false;
    public int L1Time;
    public int L1Score;
    public int L2Time;
    public int L2Score;
    public int L3Time;
    public int L3Score;

    public TextMeshProUGUI L1TimeText;
    public TextMeshProUGUI L1ScoreText;
    public TextMeshProUGUI L2TimeText;
    public TextMeshProUGUI L2ScoreText;
    public TextMeshProUGUI L3TimeText;
    public TextMeshProUGUI L3ScoreText;

    void Start()
    {
        GameObject.DontDestroyOnLoad(gameObject);
        L1Time = -1;
        L1Score = -1;
        L2Time = -1;
        L2Score = -1;
        L3Time = -1;
        L3Score = -1;
    }

    void Update()
    {
        print("L1T: "+ L1Time);
        print("L1S: " + L1Score);
        if (L1Time == -1)
        {
            L1TimeText.text = "N/A";
            L1ScoreText.text = "N/A";
        }
        else
        {
            L1TimeText.text = L1Time.ToString();
            L1ScoreText.text = L1Score.ToString();
        }
        if (L2Time == -1)
        {
            L2TimeText.text = "N/A";
            L2ScoreText.text = "N/A";
        }
        else
        {
            L2TimeText.text = L1Time.ToString();
            L2ScoreText.text = L1Score.ToString();
        }
        if (L3Time == -1)
        {
            L3TimeText.text = "N/A";
            L3ScoreText.text = "N/A";
        }
        else
        {
            L3TimeText.text = L1Time.ToString();
            L3ScoreText.text = L1Score.ToString();
        }
    }
}
