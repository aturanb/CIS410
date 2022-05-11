using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase : MonoBehaviour
{
    public GameObject player;
    

    Rigidbody m_Rigidbody;
    bool onGround;
    //float time = 0;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.freezeRotation = true;
        //print(spawnGround.transform.position);
        
    }

    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.transform.position - transform.position), 5 * Time.deltaTime);
        transform.position += transform.forward * 2 * Time.deltaTime;
        
    }
}
