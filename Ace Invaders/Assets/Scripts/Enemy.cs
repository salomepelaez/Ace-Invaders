using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    GameObject enemie;
    void Start()
    {
        Initialize();
        InvokeRepeating("Movement", 3f, 5f);
    }
       
    int enemies = 3;
    
    void Initialize()
    {
        for(int x = 0; x < enemies; x++)
        {
            Vector3 pos = new Vector3();
            enemie = GameObject.CreatePrimitive(PrimitiveType.Cube);

            pos.x = Random.Range(-8.17f, 8.17f);
            pos.y = 1.5f;
            pos.z = Random.Range(-73.5f, 74f); 
            enemie.transform.position = pos;
        }
    }

    float speed = 2f;
    void Movement()
    {
        switch(Random.Range(0, 1))
        {
            case 0:
                transform.position += transform.right * speed;
                Debug.Log("moving");
                break;

            case 1:
                transform.position -= transform.right * speed;
                break;
        }
    }
}
