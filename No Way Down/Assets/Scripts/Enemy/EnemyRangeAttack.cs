using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRangeAttack : MonoBehaviour
{
    [Header("Projectile Speed")]
    [SerializeField] float speed;

    public GameObject player;
    public GameObject Projectile;
    public Transform LaunchPosition;
    private Animator ani;
    Vector3 direction;
    Rigidbody p_Rigidbody;
    float triTime = 0;
    bool alive = true;
    [Header("Attack Range")]
    [SerializeField] float range;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        ani = GetComponent<Animator>();
        p_Rigidbody = player.GetComponent<Rigidbody>();
    }

    void Update()
    {
        direction = player.transform.position - transform.position;
        direction = direction.normalized;
        direction.y = direction.y - 0.15f;
        triTime -= Time.fixedDeltaTime;
        if (Vector3.Distance(player.transform.position, transform.position) <= range)
        {
            if (triTime <= 0 && alive == true)
            {
                ani.SetBool("Attack", true);
                GameObject P = Instantiate(Projectile, LaunchPosition.position, LaunchPosition.rotation) as GameObject;
                P.GetComponent<Rigidbody>().velocity = direction * speed;
                triTime = 5f;
            }
        }
    }

    

    public void stopAttack()
    {
        alive = false;
    }

}
