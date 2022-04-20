using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDeath : MonoBehaviour
{
    void Update()
    {
        if (transform.position.y < -15)
        {
            Destroy(gameObject);
        }
    }
}
