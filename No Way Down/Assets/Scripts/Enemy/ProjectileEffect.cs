using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileEffect : MonoBehaviour
{
    public GameObject player;
    Vector3 direction;
    Rigidbody p_Rigidbody;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
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
        if (other.tag == "Player")
        {
            p_Rigidbody.AddForce(direction * 10f, ForceMode.Impulse);
            p_Rigidbody.AddForce((Vector3.up) * 4f, ForceMode.Impulse);
        }
    }
}
