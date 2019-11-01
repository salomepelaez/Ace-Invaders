using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int life = 100;
    public GameObject bullet;
    int counter;
    public static bool next;
    bool move;

    public void Start()
    {        
        InvokeRepeating("FirstMovement", 2f, 1f);
        InvokeRepeating("Movement", 2f, 1f);
    }

    float speed = 0.2f;
    Behaviour behaviour;

    void FirstMovement()
    {
        if (Dialogue.active == true && gameObject.transform.position.z >= -74f)
        {
            transform.position -= transform.forward * speed;

            if (gameObject.transform.position.z <= -74f)
                move = true;
        }
    }

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

        if(move == true)
        {
            if (behaviour == Behaviour.Left && gameObject.transform.position.x >= -8.17f)
            {
                gameObject.transform.position -= transform.right * speed;
            }

            else if (behaviour == Behaviour.Right && gameObject.transform.position.x <= 8.17f)
            {
                gameObject.transform.position += transform.right * speed;

                if (gameObject.transform.position.x >= 8.17)
                {
                    behaviour = Behaviour.Left;
                }
            }
        }   
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Bullet")
        {
            life = life - Bullet.weaponDamage;

            if (life <= 0)
            {
                Destroy(gameObject);
                counter++;

                if (counter == 3)
                    next = true;

                Debug.Log(counter);
            }
        }
    }
       
    enum Behaviour
    {
        Right, Left
    }
}
