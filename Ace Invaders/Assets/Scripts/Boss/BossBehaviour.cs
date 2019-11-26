using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BossBehaviour : MonoBehaviour
{
    public static int damage = 1;
    public static int bossLife;    
    public static float speed;
    
    Behaviour behaviour;

    private bool move;

    public TextMeshProUGUI winner;

    public GameObject buttonShoot;
    public GameObject buttonFreeze;

    void Awake()
    {
        transform.tag = "Enemy";        
    }

    private void Start()
    {        
        speed = 3f;
        bossLife = 50;

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
        if(Manager3.inGame == true && FinalDialogue.active && move == true)
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
                
            bossLife = bossLife - PlayerController2.playerDamage; 

            if(bossLife <= 0)
            {
                Destroy(gameObject);
                winner.text = "You are now our hero";
                Manager3.inGame = false;

                buttonFreeze.SetActive(false);
                buttonShoot.SetActive(false);
            } 
        }        
    }
       
    enum Behaviour
    {
        Right, Left
    }
}
