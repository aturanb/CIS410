using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpToStart : MonoBehaviour
{
    public GameObject player;
    bool NextLevel = false;
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
    }

    void EndLevel(bool next)
    {
        if (next)
        {
            SceneManager.LoadScene(0);
        }
        /*else
        {

        }*/
    }
}