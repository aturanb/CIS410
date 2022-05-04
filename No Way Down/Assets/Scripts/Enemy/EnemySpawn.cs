using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyRoot;
    GameObject enemy;
    float time = 0;
    int maxEnemy = 5;
    int currentEnemy = 0;

    void Update()
    {
        if (time>5 && currentEnemy < maxEnemy )
        {
            enemy = Instantiate(enemyRoot, transform.position, transform.rotation);
            enemy.transform.SetParent(transform);
            time = 0;
            currentEnemy++;
        }
        time += Time.deltaTime;
    }
}
