using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plane : MonoBehaviour
{
    float speed = 0.1f;

    void Update()
    {
        if(Dialogue.active == true)
        Move();
    }

    void Move()
    {      
        if (Input.GetKey(KeyCode.W) && gameObject.transform.position.z <= -72f)
        {
            transform.position += transform.forward * speed;
        }

        if (Input.GetKey(KeyCode.S) && gameObject.transform.position.z >= -80f)
        {
            transform.position -= transform.forward * speed;
        }

        if (Input.GetKey(KeyCode.D) && gameObject.transform.position.x <= 8.17f)
        {
            transform.position += transform.right * speed;
        }

        if (Input.GetKey(KeyCode.A) && gameObject.transform.position.x >= -8.17f)
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
