using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    float speed = 0.1f;

    void Update()
    {
        Move();
    }

    void Move()
    {      
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += transform.forward * speed;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position -= transform.forward * speed;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += transform.right * speed;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position -= transform.right * speed;
        }

        Vector3 pos = new Vector3();
        if (pos.x >= -8.17f)
        {
            pos.x = -8.17f;
        }

        else if (pos.x >= 8.17f)
        {
            pos.x = 8.17f;
        }

        else if (pos.y > -3)
        {
            pos.y = -3;
        }

        else if (pos.y > 5)
        {
            pos.y = 5;
        }

        else if (pos.z >= -88.3)
        {
            pos.z = -88.3f;
        }

        else if (pos.z >= 88.3)
        {
            pos.z = 88.3f;
        }
    }

}
