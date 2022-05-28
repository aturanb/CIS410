using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class recordDisplay : MonoBehaviour
{
    public TextMeshProUGUI L1TimeText;
    public TextMeshProUGUI L1ScoreText;
    public TextMeshProUGUI L2TimeText;
    public TextMeshProUGUI L2ScoreText;
    public TextMeshProUGUI L3TimeText;
    public TextMeshProUGUI L3ScoreText;


    public GameObject L2TimeGB;
    public GameObject L2ScoreGB;
    public GameObject L3TimeGB;
    public GameObject L3ScoreGB;
    public GameObject L2Button;
    public GameObject L3Button;
    public int L1Time ;
    public int L1Score;
    public int L2Time;
    public int L2Score;
    public int L3Time ;
    public int L3Score ;
    public bool L2 ;
    public bool L3 ;
    public GameObject dataSave;

    public bool L1NA;
    public bool L2NA;
    public bool L3NA;

    void Start()
    {
        dataSave = GameObject.FindGameObjectWithTag("Data");
        L2 = dataSave.GetComponent<DataSave>().L2;
        L3 = dataSave.GetComponent<DataSave>().L3;
        L1Time = dataSave.GetComponent<DataSave>().L1Time;
        L1Score = dataSave.GetComponent<DataSave>().L1Score;
        L2Time = dataSave.GetComponent<DataSave>().L2Time;
        L2Score = dataSave.GetComponent<DataSave>().L2Score;
        L3Time = dataSave.GetComponent<DataSave>().L3Time;
        L3Score = dataSave.GetComponent<DataSave>().L3Score;
        L1NA = dataSave.GetComponent<DataSave>().L1NA;
        L2NA = dataSave.GetComponent<DataSave>().L2NA;
        L3NA = dataSave.GetComponent<DataSave>().L3NA;
    }

    void Update()
    {
        if (L1NA==true)
        {
            L1TimeText.text = "N/A";
            L1ScoreText.text = "N/A";
        }
        else
        {
            L1TimeText.text = L1Time.ToString()+"s";
            L1ScoreText.text = L1Score.ToString();
        }
        if (L2 == true)
        {
            L2TimeGB.SetActive(true);
            L2ScoreGB.SetActive(true);
            L2Button.SetActive(true);
            if (L2NA == true)
            {
                L2TimeText.text = "N/A";
                L2ScoreText.text = "N/A";
            }
            else
            {
                L2TimeText.text = L2Time.ToString() + "s";
                L2ScoreText.text = L2Score.ToString();
            }
        }
        else
        {
            L2TimeGB.SetActive(false);
            L2ScoreGB.SetActive(false);
            L2Button.SetActive(false);
        }
        if (L3 == true)
        {
            L3TimeGB.SetActive(true);
            L3ScoreGB.SetActive(true);
            L3Button.SetActive(true);
            if (L3NA == true)
            {
                L3TimeText.text = "N/A";
                L3ScoreText.text = "N/A";
            }
            else
            {
                L3TimeText.text = L3Time.ToString() + "s";
                L3ScoreText.text = L3Score.ToString();
            }
        }
        else
        {
            L3TimeGB.SetActive(false);
            L3ScoreGB.SetActive(false);
            L3Button.SetActive(false);
        }
    }
}
