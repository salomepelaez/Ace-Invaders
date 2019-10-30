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

    Vector3 pos = new Vector3();
    void Initialize()
    {
        int enemies = 3;
        for (int x = 0; x < enemies; x++)
        {
            enemie = GameObject.CreatePrimitive(PrimitiveType.Cube);

            pos.x = Random.Range(-8.17f, 8.17f);
            pos.y = 1.8f;
            pos.z = Random.Range(-73.5f, -74f); 
            enemie.transform.position = pos;
            
            InvokeRepeating("Movement", 3f, 1f);
        }
    }

    float speed = 0.2f;
    Behaviour behaviour;
    void Movement()
    {
        switch (Random.Range(0, 2))
        {
            case 0:
                behaviour = Behaviour.Left;
                break;

            case 1:
                behaviour = Behaviour.Right;
                break;
        }

        if (behaviour == Behaviour.Left && enemie.transform.position.x >= -8.17f)
        {
            enemie.transform.position -= transform.right * speed;
        }

        else if (behaviour == Behaviour.Right && enemie.transform.position.x <= 8.17f)
        {
            enemie.transform.position += transform.right * speed;

            if (enemie.transform.position.x >= 8.17)
            {
                Debug.Log("lel");
                behaviour = Behaviour.Left;
            }
        }

        
            
    }

    enum Behaviour
    {
        Right, Left
    }
}
