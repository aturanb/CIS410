using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public GameObject player;
    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    void Update()
    {
        var direction = (player.transform.position - transform.position).normalized;
        transform.Translate(direction * Time.deltaTime*2);
    }
}
