using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    float speed = 0.1f;
    public TextMeshProUGUI lifeCounter;
    public TextMeshProUGUI gameOver;
    public int life;

    public AudioSource music;
    public AudioSource key;
    public AudioSource enemyDamage;
    public AudioSource loss;
    public AudioSource gameOverSound;
    public AudioSource sadMusic;

    void Start()
    {
        music.Play();
        life = 3;
    }

    void Awake()
    {
        gameObject.layer = 10;
        transform.tag = "Player";
    }

    void Update()
    {
        if (Messages.goAhead == true) 
        {
            Move();            
        }       

        lifeCounter.text = "Life: " + life;

        if (life <= 0)
        {
            lifeCounter.text = "";
            gameOver.text = "You died!";
            music.Stop();
            loss.Play();
            gameOverSound.Play();
            sadMusic.Play();
        }   
    }

    void Move()
    {    
        if(Manager2.inGame == true)
        {
            if (Input.GetKey(KeyCode.W) && gameObject.transform.position.z <= 8f)
            {
                transform.position += transform.forward * speed;
                key.Play();
            }

            if (Input.GetKey(KeyCode.S) && gameObject.transform.position.z >= -0.4f)
            {
                transform.position -= transform.forward * speed;
                key.Play();
            }

            if (Input.GetKey(KeyCode.D) && gameObject.transform.position.x <= 6f)
            {
                transform.position += transform.right * speed;
                key.Play();
            }

            if (Input.GetKey(KeyCode.A) && gameObject.transform.position.x >= -6f)
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
                Manager2.inGame = false;
        }
    }
}
