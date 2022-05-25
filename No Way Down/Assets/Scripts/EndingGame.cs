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
    float EndDelay = 7f;
    public TextMeshProUGUI TimeCostText;
    public Timer timer;
    public GameObject TimeCost;

    void Start()
    {
        winTextObject.SetActive(false);
        TimeCost.SetActive(false);
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
            winTextObject.SetActive(true);
            Time.timeScale = 0;
            Ending = true;
        }
    }
}
