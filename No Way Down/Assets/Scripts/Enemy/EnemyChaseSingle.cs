using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyChaseSingle : MonoBehaviour
{
    public GameObject player;
    [Header("Chase")]
    [SerializeField] float range;
    [SerializeField] float speed;
    Rigidbody m_Rigidbody;
    bool onGround;

    public GameObject crowbar;
    bool stopping;
    bool attacking;
    private Animator ani;
    float time = 0;
    bool chase = true;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        crowbar = GameObject.FindGameObjectWithTag("Hand with Crowbar");
        ani = crowbar.GetComponent<Animator>();
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.freezeRotation = true;
    }

    void Update()
    {
        if (chase == true)
        {
            attacking = ani.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Armature|Crowbar -hit3");
            if (Vector3.Distance(player.transform.position, transform.position) <= range && stopping == false)
            {
                Vector3 temp = player.transform.position - transform.position;
                temp.y = 0;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(temp), 5 * Time.deltaTime);
                transform.position += transform.forward * speed * Time.deltaTime;

            }
            else if (stopping == true && time >= 0.5f)
            {
                stopping = false;
                time = 0;
            }
            time += Time.deltaTime;
        }  
    }

    void OnTriggerEnter(Collider collider)
    {
        if (attacking == true)
        {
            stopping = true;
        }
    }

    void OnTriggerStay(Collider collider)
    {
        if (attacking == true)
        {
            stopping = true;
        }
    }

    void OnTriggerExit(Collider collider)
    {
        if (attacking == true)
        {
            stopping = true;
        }
    }

    public void stopChase()
    {
        chase = false;
    }
}
