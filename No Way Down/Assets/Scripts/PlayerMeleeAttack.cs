using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMeleeAttack : MonoBehaviour
{
    Animator slash;
    private void Start()
    {
        slash = GetComponent<Animator>();
    }

    
    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            slash.SetBool("Attacking", true);
        }
        else if (Input.GetButtonUp("Fire1"))
        {
            slash.SetBool("Attacking", false);
        }
    }
}
