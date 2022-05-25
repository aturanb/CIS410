using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class JumpToStart : MonoBehaviour
{
    public GameObject player;
    bool NextLevel = false;
    public static float timeScale { get; set; }
    
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
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.Confined;
            SceneManager.LoadScene(0);
        }
        /*else
        {

        }*/
    }
}
