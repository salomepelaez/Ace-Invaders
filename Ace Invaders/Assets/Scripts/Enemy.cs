using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    void Start()
    {
        InvokeRepeating("Movement", 3f, 1f);
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

        if (behaviour == Behaviour.Left && gameObject.transform.position.x >= -8.17f)
        {
            gameObject.transform.position -= transform.right * speed;
        }

        else if (behaviour == Behaviour.Right && gameObject.transform.position.x <= 8.17f)
        {
            gameObject.transform.position += transform.right * speed;

            if (gameObject.transform.position.x >= 8.17)
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
