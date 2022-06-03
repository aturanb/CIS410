using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFaceSingle : MonoBehaviour
{
    public GameObject player;
    public AudioSource sound;
    [Header("Face Range")]
    [SerializeField] float range;
    Rigidbody m_Rigidbody;
    bool onGround;

    private Animator ani;
    bool face = true;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        m_Rigidbody = GetComponent<Rigidbody>();
        m_Rigidbody.freezeRotation = true;
    }

    void Update()
    {
        if (face == true)
        {
            sound.Play();
            if (Vector3.Distance(player.transform.position, transform.position) <= range)
            {
                Vector3 temp = player.transform.position - transform.position;
                temp.y = 0;
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(temp), 5 * Time.deltaTime);
                

            }
        }  
    }

    public void stopFace()
    {
        face = false;
    }
}
