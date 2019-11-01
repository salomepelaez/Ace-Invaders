using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator : MonoBehaviour
{
    public GameObject enemy;

    void Start()
    {
        InvokeRepeating("Create", 1f, 3f);
        enemy.AddComponent<EnemyController>().FirstMovement();
    }

    void Create()
    {
        for(int x = 0; x < 20; x++)
        {
            GameObject e = Instantiate(enemy) as GameObject;

            Vector3 pos = new Vector3();
            pos.x = Random.Range(-4.74f, 5.37f);
            pos.y = 1.66f;
            pos.z = 9.65f;

            e.transform.position = pos;
        }
    }
}
