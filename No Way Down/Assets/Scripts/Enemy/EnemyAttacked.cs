using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttacked : MonoBehaviour
{
    bool attacking;
    private Animator ani;
    private Animator m_ani;
    public GameObject player;
    Rigidbody m_Rigidbody;
    Vector3 direction;
    int death;

    
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Hand with Crowbar");
        ani = player.GetComponent<Animator>();
        m_Rigidbody = gameObject.transform.parent.GetComponent<Rigidbody>();
        m_ani= GetComponent<Animator>();
    }

    
    void Update()
    {
        if (death >= 10)
        {
            gameObject.SetActive(false);
        }
        
        direction = new Vector3((player.transform.position.x - transform.position.x), 0, (player.transform.position.z - transform.position.z));
        direction = direction.normalized;
        direction.x = direction.x * (-0.7f);
        direction.z = direction.z * (-0.7f);
        attacking = ani.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Armature|Crowbar -hit3");
    }
    

    void OnTriggerEnter(Collider collider)
    {
        if (attacking == true)
        {
            //death++;
            m_Rigidbody.AddForce(direction, ForceMode.Impulse);
            m_Rigidbody.AddForce((Vector3.up) * 0.5f, ForceMode.Impulse);
        }
    }

    void OnTriggerStay(Collider collider)
    {
        if (attacking == true)
        {
            death++;
            m_Rigidbody.AddForce(direction, ForceMode.Impulse);
            m_Rigidbody.AddForce((Vector3.up)*0.5f, ForceMode.Impulse);
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (attacking == true)
        {
            //death++;
            m_Rigidbody.AddForce(direction, ForceMode.Impulse);
            m_Rigidbody.AddForce((Vector3.up) * 0.5f, ForceMode.Impulse);
        }
    }
}
