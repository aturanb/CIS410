using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase2 : MonoBehaviour
{
    public GameObject player;
    public GameObject spawnGround;

    Rigidbody m_Rigidbody;
    bool onGround;
    //float time = 0;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spawnGround = GameObject.FindGameObjectWithTag("spawnGround2");
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.freezeRotation = true;
        //print(spawnGround.transform.position);

    }

    void Update()
    {
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.transform.position - transform.position), 5 * Time.deltaTime);
        transform.position += transform.forward * 2 * Time.deltaTime;
        /*if (onGround==true)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.transform.position - transform.position), 5 * Time.deltaTime);      
            transform.position += transform.forward * 2 * Time.deltaTime;
        }
        else if (onGround ==false && time>=1)
        {
            
            Vector3 temp = new Vector3(spawnGround.transform.position.x - transform.position.x, transform.position.y, spawnGround.transform.position.z - transform.position.z);
            var back = temp.normalized;
            m_Rigidbody.AddForce(-(transform.forward), ForceMode.Impulse);
            time = 0;
        }
        time += Time.deltaTime;*/
    }

    /*void OnCollisionExit(Collision other)
    {
        if (other.gameObject.tag == "spawnGround1" )
        {
            onGround = false;
            
        }
        else
        {
            onGround = true;
        }
    }*/
}
