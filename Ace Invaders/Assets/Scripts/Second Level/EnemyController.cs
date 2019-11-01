﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public int life = 100;
    public GameObject bullet;
    int counter;

    bool move;
    public static bool next;

    public void Start()
    {
        InvokeRepeating("FirstMovement", 2f, 1f);
        if (move == true)
            InvokeRepeating("Movement", 2f, 1f);
    }

    float speed = 0.2f;
    Behaviour behaviour;

    public void FirstMovement()
    {        
        if (gameObject.transform.position.z >= 4f)
            transform.position -= transform.forward * speed;

        if (gameObject.transform.position.z <= 4f)
            move = true;
        
    }

    public void Movement()
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
                
        if (behaviour == Behaviour.Left && gameObject.transform.position.x >= -6f)
        {
            gameObject.transform.position -= transform.right * speed;
        }

        else if (behaviour == Behaviour.Right && gameObject.transform.position.x <= 6)
        {
            gameObject.transform.position += transform.right * speed;

            if (gameObject.transform.position.x >= 8.17)
            {
                behaviour = Behaviour.Left;
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

                //Debug.Log(next);
            }
        }
    }
       
    enum Behaviour
    {
        Right, Left
    }
}
