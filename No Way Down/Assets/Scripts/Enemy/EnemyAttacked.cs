using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyAttacked : MonoBehaviour
{
    bool attacking;
    private Animator ani;
    private Animator m_ani;
    public GameObject player;
    public EnemyChaseSingle ecs;
    public EnemyAttack ea;
    public Score score;

    Rigidbody m_Rigidbody;
    Vector3 direction;
    int death;
    float triTime = 0f;
    bool alive = true;
    float destroyTime = 3f;
    float cos, angle;

    [Header("Death")]
    [SerializeField] int attacted;

    [Header("Score Type")]
    [SerializeField] int sType;


    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Hand with Crowbar");
        ani = player.GetComponent<Animator>();
        m_Rigidbody = gameObject.transform.parent.GetComponent<Rigidbody>();
        m_ani= GetComponent<Animator>();
    }

    
    void Update()
    {
        Vector3 playerDirection = player.transform.TransformDirection(Vector3.forward);
        Vector3 zombiePosition = transform.position - player.transform.position;
        cos = Vector3.Dot(playerDirection, zombiePosition);
        angle = Mathf.Acos(Vector3.Dot(playerDirection.normalized, zombiePosition.normalized)) * Mathf.Rad2Deg;
        if (death >= attacted && alive == true)
        {

            alive = false;
            ea.stopAttack();
            ecs.stopChase();
            score.getScore(sType);
            m_ani.SetTrigger("Dead");
        }
        if (alive == false)
        {
            destroyTime -= Time.fixedDeltaTime;
            if (destroyTime <= 0)
            {
                Destroy(this.transform.parent.gameObject);
            }
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
            if (triTime <= 0 && alive == true && cos > 0 && angle < 60 && Vector3.Distance(player.transform.position, transform.position) <= 3)
            {
                death++;
                m_Rigidbody.AddForce(direction * 6f, ForceMode.Impulse);
                m_Rigidbody.AddForce((Vector3.up) * 3f, ForceMode.Impulse);
                triTime = 0.5f;
            } 
        }
    }
}
