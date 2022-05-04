using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase1 : MonoBehaviour
{
    public GameObject player;
    public GameObject spawnGround1;
    float xMax, xMin, zMax, zMin, surface;
    Rigidbody m_Rigidbody;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spawnGround1 = GameObject.FindGameObjectWithTag("spawnGround1");
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.freezeRotation = true;
        xMax = (spawnGround1.transform.position.x + (spawnGround1.transform.localScale.x / 2));
        xMin = (spawnGround1.transform.position.x - (spawnGround1.transform.localScale.x / 2));
        zMax = (spawnGround1.transform.position.z + (spawnGround1.transform.localScale.z / 2));
        zMin = (spawnGround1.transform.position.z - (spawnGround1.transform.localScale.z / 2));
        surface = spawnGround1.transform.position.y + (spawnGround1.transform.localScale.y / 2);
    }
    void Update()
    {
        if (xMin <= transform.position.x && transform.position.x <= xMax && zMin <= transform.position.z && transform.position.z <= zMax)
        {
            var direction = (player.transform.position - transform.position).normalized;
            transform.Translate(direction * Time.deltaTime * 2);
        }
        else
        {

            Vector3 temp = new Vector3(spawnGround1.transform.position.x - transform.position.x, transform.position.y, spawnGround1.transform.position.z - transform.position.z);
            var back = temp.normalized;
            m_Rigidbody.AddForce(back, ForceMode.Impulse);
        }
    }
}
