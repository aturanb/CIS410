using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndingGame : MonoBehaviour
{
    public GameObject player;
    bool EndGame = false;
    public GameObject winTextObject;
    void Start()
    {
        winTextObject.SetActive(false);
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
    }

    void EndLevel(bool next)
    {
        if (next)
        {
            winTextObject.SetActive(true);
            if(Input.GetKey(KeyCode.Escape))
                SceneManager.LoadScene(0);
        }
        /*else
        {

        }*/
    }
}
