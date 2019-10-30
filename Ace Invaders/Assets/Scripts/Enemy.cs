using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject enemie;
    void Start()
    {
        Initialize();
    }

    private void Update()
    {
        Movement();
    }

    int enemies = 3;
    
    void Initialize()
    {
        for(int x = 0; x < enemies; x++)
        {
            Vector3 pos = new Vector3();
            enemie = GameObject.CreatePrimitive(PrimitiveType.Cube);

            pos.x = Random.Range(-8.17f, 8.17f);
            pos.y = Random.Range(-3, 5);
            pos.z = -78;
            enemie.transform.position = pos;
        }
    }

    float speed = 0.5f;
    void Movement()
    {
        switch(Random.Range(0, 1))
        {
            case 0:
                transform.position += transform.right * speed;
                break;
        }
    }
}
