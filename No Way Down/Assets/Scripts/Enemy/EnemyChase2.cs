using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChase2 : MonoBehaviour
{
    public GameObject player;
    public GameObject spawnGround2;
    float xMax, xMin, zMax, zMin, surface;
    Rigidbody m_Rigidbody;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        spawnGround2 = GameObject.FindGameObjectWithTag("spawnGround2");
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.freezeRotation = true;
        xMax = (spawnGround2.transform.position.x + (spawnGround2.transform.localScale.x / 2));
        xMin = (spawnGround2.transform.position.x - (spawnGround2.transform.localScale.x / 2));
        zMax = (spawnGround2.transform.position.z + (spawnGround2.transform.localScale.z / 2));
        zMin = (spawnGround2.transform.position.z - (spawnGround2.transform.localScale.z / 2));
        surface = spawnGround2.transform.position.y + (spawnGround2.transform.localScale.y / 2);
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

            Vector3 temp = new Vector3(spawnGround2.transform.position.x - transform.position.x, transform.position.y, spawnGround2.transform.position.z - transform.position.z);
            var back = temp.normalized;
            m_Rigidbody.AddForce(back, ForceMode.Impulse);
        }

    }
}