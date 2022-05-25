using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class JumpToLevel2 : MonoBehaviour
{
    public GameObject player;
    bool NextLevel = false;
    float JumpDelay = 7f;
    bool Ending = false;
    public TextMeshProUGUI TimeCostText;
    public Timer timer;
    public GameObject TimeCost;

    public static float timeScale { get; set; }

    void Start()
    {
        TimeCost.SetActive(false);
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
            SceneManager.LoadScene(3);
        }
    }

    void EndLevel(bool next)
    {
        if (next)
        {
            TimeCostText.text = "Time Cost: "+timer.getTime().ToString()+"s";
            TimeCost.SetActive(true);
            Time.timeScale = 0;
            Ending = true;
            
        }
    }
}
