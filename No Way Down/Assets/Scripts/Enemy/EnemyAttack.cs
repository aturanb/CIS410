using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    
    public GameObject player;
    private Animator ani;
    Vector3 direction;
    Rigidbody p_Rigidbody;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ani = GetComponent<Animator>();
        p_Rigidbody = player.GetComponent<Rigidbody>();
    }

    void Update()
    {
        direction = new Vector3((player.transform.position.x - transform.position.x), 0, (player.transform.position.z - transform.position.z));
        direction = direction.normalized;
        direction.x = direction.x * (0.7f);
        direction.z = direction.z * (0.7f);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == player)
        {
            ani.SetBool("Attack", true);
            p_Rigidbody.AddForce(direction, ForceMode.Impulse);
            p_Rigidbody.AddForce((Vector3.up) * 0.5f, ForceMode.Impulse);
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject == player)
        {
            ani.SetBool("Attack", true);
            p_Rigidbody.AddForce(direction, ForceMode.Impulse);
            p_Rigidbody.AddForce((Vector3.up) * 0.5f, ForceMode.Impulse);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject == player)
        {
            ani.SetBool("Attack", true);
            p_Rigidbody.AddForce(direction, ForceMode.Impulse);
            p_Rigidbody.AddForce((Vector3.up) * 0.5f, ForceMode.Impulse);
        }
    }
}
