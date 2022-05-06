using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase1 : MonoBehaviour
{
    public GameObject player;
    public GameObject spawnGround;
    float xMax, xMin, zMax, zMin, surface;
    Rigidbody m_Rigidbody;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spawnGround = GameObject.FindGameObjectWithTag("spawnGround1");
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.freezeRotation = true;
        xMax = (spawnGround.transform.position.x + (spawnGround.transform.localScale.x / 2));
        xMin = (spawnGround.transform.position.x - (spawnGround.transform.localScale.x / 2));
        zMax = (spawnGround.transform.position.z + (spawnGround.transform.localScale.z / 2));
        zMin = (spawnGround.transform.position.z - (spawnGround.transform.localScale.z / 2));
        surface = spawnGround.transform.position.y + (spawnGround.transform.localScale.y / 2);
    }
    void Update()
    {
        if (xMin <= transform.position.x && transform.position.x <= xMax && zMin <= transform.position.z && transform.position.z <= zMax)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.transform.position - transform.position), 5 * Time.deltaTime);      
            transform.position += transform.forward * 2 * Time.deltaTime;
        }
        else
        {

            Vector3 temp = new Vector3(spawnGround.transform.position.x - transform.position.x, transform.position.y, spawnGround.transform.position.z - transform.position.z);
            var back = temp.normalized;
            m_Rigidbody.AddForce(back, ForceMode.Impulse);
        }
     
    }
}
