using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController2 : MonoBehaviour
{
    float speed = 0.1f;
    public TextMeshProUGUI lifeCounter;
    public static int life;
    public static int playerDamage;

    public AudioSource key;
    public AudioSource enemyDamage;
    
    void Start()
    {
        life = 3;
    }

    void Awake()
    {
        gameObject.layer = 10;
        transform.tag = "Player";
    }

    void Update()
    {
        Move();            
          

        lifeCounter.text = "Life: " + life;

        if(life <= 0)
            lifeCounter.text = "";
            
    }

    void Move()
    {    
        if(Manager3.inGame == true)
        {
            if (Input.GetKey(KeyCode.W) && gameObject.transform.position.z <= -8f)
            {
                transform.position += transform.forward * speed;
                key.Play();
            }

            if (Input.GetKey(KeyCode.S) && gameObject.transform.position.z <= -14f)
            {
                transform.position -= transform.forward * speed;
                key.Play();
            }

            if (Input.GetKey(KeyCode.D) && gameObject.transform.position.x >= -6.5)
            {
                transform.position += transform.right * speed;
                key.Play();
            }

            if (Input.GetKey(KeyCode.A) && gameObject.transform.position.x <= -10f)
            {
                transform.position -= transform.right * speed;
                key.Play();
            }
        }
    }    
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            enemyDamage.Play();
            life = life - EnemyController.damage;
            
            if(life <= 0)
                Manager3.inGame = false;
        }

        if (other.transform.tag == "BossBullet")
        {
            enemyDamage.Play();
            life = life - BossBehaviour.damage;
            
            if(life <= 0)
                Manager3.inGame = false;
        }
    }
}
