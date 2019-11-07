using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossBehaviour : MonoBehaviour
{
    public static int damage = 1;
    public static int bossLife = 10;
    
    public static float speed;
    
    Behaviour behaviour;

    bool move;

    GameObject bullet;
    GameObject allies;

    void Awake()
    {
        transform.tag = "Enemy";        
    }

    private void Start()
    {        
        speed = 2f;

        InvokeRepeating("Movement", 1f, 2f);    
    }

    private void Update()
    {
        GetCloser();
    }

    void GetCloser()
    {
        float getCloserSpeed = 0.5f;
        
        if(FinalDialogue.active == true && gameObject.transform.position.z >= -9f)
        {
            gameObject.transform.position -= transform.forward * getCloserSpeed * Time.deltaTime;
            move = true;
        }
    }

    void Movement()
    {
        if(Manager3.inGame == true && move == true)
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
                    
            if (behaviour == Behaviour.Left && gameObject.transform.position.x >= -5.5f)
            {
                gameObject.transform.position -= transform.right * speed;

                if (gameObject.transform.position.x <= -5.5f)
                {
                    behaviour = Behaviour.Right;
                }
            }

            else if (behaviour == Behaviour.Right && gameObject.transform.position.x <= 9.8f)
            {
                gameObject.transform.position += transform.right * speed;

                if (gameObject.transform.position.x >= 9.8f)
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
            Manager3.counterValue += 100;
            CreateAllies();
                
            bossLife = bossLife - PlayerController2.playerDamage; 

            if(bossLife <= 0)
            {
                Destroy(gameObject);
                Manager3.winner = true;                    
            }

            Debug.Log(bossLife);      
        }
        
    }

    void CreateAllies()
    {
        allies = GameObject.CreatePrimitive(PrimitiveType.Cube);
        allies.layer = 9;
        allies.transform.tag = "Enemy";
        allies.AddComponent<BoxCollider>();
        allies.GetComponent<BoxCollider>().isTrigger = true;
        allies.AddComponent<Rigidbody>();
        Vector3 pos = new Vector3();
        pos.x = Random.Range(-5.6f, 10f);
        pos.y = 0.1f;
        pos.z = -4.5f;

        allies.transform.position = pos;

        allies.transform.position -= transform.forward * speed;

    }
       
    enum Behaviour
    {
        Right, Left
    }
}
