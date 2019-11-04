using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    float speed = 3f;

    void Update()
    {
        if(Dialogue.active == true)
        {
            if(Manager.inGame == true)
            {
                Move();
            }
        }        
    }

    void Move()
    {      
        if (Input.GetKey(KeyCode.W) && gameObject.transform.position.z <= -72f)
        {
            transform.position += transform.forward * speed *  Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.S) && gameObject.transform.position.z >= -80f)
        {
            transform.position -= transform.forward * speed *  Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.D) && gameObject.transform.position.x <= 8.17f)
        {
            transform.position += transform.right * speed *  Time.deltaTime;
        }

        if (Input.GetKey(KeyCode.A) && gameObject.transform.position.x >= -8.17f)
        {
            transform.position -= transform.right * speed *  Time.deltaTime;
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

    int life = 3;
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            life = life - Enemy.damage;
            Debug.Log(life);

            if(life <= 0)
                Manager.inGame = false;
        }
    }
}
