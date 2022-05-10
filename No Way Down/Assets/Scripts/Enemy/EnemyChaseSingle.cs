using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseSingle : MonoBehaviour
{
    public GameObject player;
    [Header("Chase Range")]
    [SerializeField] float range;
    Rigidbody m_Rigidbody;
    bool onGround;
    


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.freezeRotation = true;
        
        
    }

    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) <= range)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(player.transform.position - transform.position), 5 * Time.deltaTime);
            transform.position += transform.forward * 2 * Time.deltaTime;
        }
        
        
    }
}
