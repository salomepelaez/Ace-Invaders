using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    int counter = 0;
    
    public bool move;
    public static bool next;

    public float speed = 0.2f;
    Behaviour behaviour;

    public GameObject bullet;
    
    void FirstMovement()
    {        
        if (gameObject.transform.position.z >= 4f)
            transform.position -= transform.forward * speed;

        if (gameObject.transform.position.z <= 4f)
            move = true;
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

    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Bullet")
        {
            counter++;
            Destroy(gameObject);

            if (counter == 10)
                Debug.Log("bien");

            next = true;

            Debug.Log(counter);
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
    private void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.yellow;
        
        if (Messages.goAhead == true)        
            InvokeRepeating("EnemyMove", 2f, 1f);
        
    }

    void EnemyMove()
    {
        transform.position -= transform.forward * speed;
    }
    
}

public class Enemy2 : EnemyController
{
    //blabla
    private void Start()
    {
        gameObject.GetComponent<Renderer>().material.color = Color.red;

        if (Messages.goAhead == true)
            InvokeRepeating("FirstMovement", 2f, 1f);

        if (Messages.goAhead == true)
        {
            if (move == true)
                InvokeRepeating("Movement", 2f, 1f);
        }
        InvokeRepeating("DoDamage", 2f, 2f);
    }

    void DoDamage()
    {
        if (Messages.goAhead == true)
        {
            bullet = GameObject.CreatePrimitive(PrimitiveType.Capsule);

            bullet.transform.localScale = new Vector3(0.095769f, 0.095769f, 0.095769f);
            bullet.transform.position = transform.position;

            bullet.AddComponent<CapsuleCollider>();
            bullet.GetComponent<CapsuleCollider>().isTrigger = true;
            bullet.AddComponent<EnemyBulletController>();
        }
    }
}
