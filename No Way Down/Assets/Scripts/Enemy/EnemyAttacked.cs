using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor.Animations;

public class EnemyAttacked : MonoBehaviour
{
    bool attacking;
    private Animator ani;
    private Animator m_ani;
    public GameObject player;
    public EnemyChaseSingle ecs;
    public EnemyAttack ea;
    public Transform zombie;
    Rigidbody m_Rigidbody;
    Vector3 direction;
    int death;
    float triTime = 0f;
    bool alive = true;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Hand with Crowbar");
        ani = player.GetComponent<Animator>();
        m_Rigidbody = gameObject.transform.parent.GetComponent<Rigidbody>();
        m_ani= GetComponent<Animator>();
    }

    
    void Update()
    {
        if (death >= 3 && alive == true)
        {
            alive = false;
            ea.stopAttack();
            ecs.stopChase();
            m_ani.SetTrigger("Dead");
            zombie.Rotate(45, 0, 0);
            //gameObject.transform.parent.GetComponent<scriptName>().enabled = true / false;
            //this.transform.parent.gameObject.SetActive(false);

            //Destroy(this.transform.parent.gameObject);
        }
        direction = new Vector3((player.transform.position.x - transform.position.x), 0, (player.transform.position.z - transform.position.z));
        direction = direction.normalized;
        direction.x = direction.x * (-0.7f);
        direction.z = direction.z * (-0.7f);
        attacking = ani.GetCurrentAnimatorStateInfo(0).IsName("Base Layer.Armature|Crowbar -hit3");
    }

    void OnTriggerStay(Collider collider)
    {
        triTime -= Time.fixedDeltaTime;
        if (attacking == true)
        { 
            if (triTime <= 0&& alive==true)
            {
                death++;
                m_Rigidbody.AddForce(direction * 6f, ForceMode.Impulse);
                m_Rigidbody.AddForce((Vector3.up) * 3f, ForceMode.Impulse);
                triTime = 0.5f;
            } 
        }
    }
}
