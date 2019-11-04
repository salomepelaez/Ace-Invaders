using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public static int damage = 1;
    
    public bool move;

    public float speed;
    
    Behaviour behaviour;

    public GameObject bullet;
    
    void FirstMovement()
    {    
        if(Manager2.inGame == true)
        {    
            if (gameObject.transform.position.z >= 4f)
                transform.position -= transform.forward * speed;

            if (gameObject.transform.position.z <= 4f)
                move = true;
        }
    }

    void Movement()
    {
        if(Manager2.inGame == true)
        {
            if (move == true)
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
        speed = 1f;
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
        speed = 0.2f;
        gameObject.GetComponent<Renderer>().material.color = Color.red;

        if (Messages.goAhead == true)
        {
        
            InvokeRepeating("FirstMovement", 1f, 1f);
            InvokeRepeating("Movement", 2f, 1f);
            InvokeRepeating("DoDamage", 3f, 1f);
            
        }
    }

    void DoDamage()
    {
        float bulletSpeed = 800f;
        
        Vector3 bulletDirection = new Vector3(0, 0.5f, -1);
        Vector3 bulletRotation = new Vector3(90, 0, 0);

        
        if(move == true)
        {
            bullet = GameObject.CreatePrimitive(PrimitiveType.Capsule);
            bullet.transform.position = transform.position;
            bullet.transform.Rotate(bulletRotation);
            Rigidbody rigidbody = bullet.AddComponent<Rigidbody>();            
            rigidbody.AddForce(bulletDirection * bulletSpeed);

            bullet.transform.localScale = new Vector3(0.095769f, 0.095769f, 0.095769f);        

            bullet.AddComponent<CapsuleCollider>();
            bullet.GetComponent<CapsuleCollider>().isTrigger = true; 

            Destroy(bullet, 3f);
        }
    }
}
