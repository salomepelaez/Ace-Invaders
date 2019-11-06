using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static int damage = 1;
    public int life = 100;

    public static bool next;
    public static bool move;

    public void Start()
    {
    
        InvokeRepeating("FirstMovement", 2f, 1f);
        InvokeRepeating("Movement", 2f, 1f);
    
    }

    public static float speed = 3f;
    Behaviour behaviour;

    void FirstMovement()
    {
        if(Manager.inGame == true)
        {
            if (Dialogue.active == true && gameObject.transform.position.z >= -74f)
            {
                transform.position -= transform.forward * speed *  Time.deltaTime;

                if (gameObject.transform.position.z <= -74f)
                    move = true;
            }
        }
    }

    void Movement()
    {       
        if(Manager.inGame == true)
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
                    gameObject.transform.position -= transform.right * speed *  Time.deltaTime;
                }

                else if (behaviour == Behaviour.Right && gameObject.transform.position.x <= 8.17f)
                {
                    gameObject.transform.position += transform.right * speed *  Time.deltaTime;

                    if (gameObject.transform.position.x >= 8.17)
                    {
                        behaviour = Behaviour.Left;
                    }
                }
            }  
        }
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Bullet")
        { 
            Manager.counterValue += 10;
            Destroy(gameObject);    
            Debug.Log(Manager.counterValue);        
        }
    }
       
    enum Behaviour
    {
        Right, Left
    }
}
