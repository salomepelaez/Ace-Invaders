using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static int damage = 1;
    
    public static float speed = 1f;
    
    Behaviour behaviour;

    void Movement()
    {
        if(Manager2.inGame == true)
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
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Bullet")
        {
            if (other.transform.tag == "Bullet")
            { 
                Manager2.counterValue += 10;
                Destroy(gameObject);    
                Debug.Log(Manager2.counterValue);        
            }
        }
    }
       
    enum Behaviour
    {
        Right, Left
    }
}

public class Enemy1 : EnemyController
{
    //blabla
    void Awake()
    {
        transform.tag = "Enemy";
    }

    private void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        
        if(Manager2.inGame == true)
        {
            if (Messages.goAhead == true)        
                InvokeRepeating("EnemyMove", 1f, 1f);        
        }        
    }

    void Update()
    {
        if(gameObject != null)
        Destroy(gameObject, 30f);
    }

    void EnemyMove()
    {
        if(Manager2.inGame == true)
            transform.position -= transform.forward * speed;
    }
}

public class Enemy2 : EnemyController
{
    void Awake()
    {
        transform.tag = "Enemy";        
    }

    private void Start()
    { 
        gameObject.GetComponent<Renderer>().material.color = Color.red;

        if (Messages.goAhead == true)
        {        
            InvokeRepeating("Movement", 1f, 1f);            
        }
    }
}
