using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController2 : MonoBehaviour
{
    public GameObject player;

    float speed = 0.1f;

    public TextMeshProUGUI lifeCounter;
    public TextMeshProUGUI gameOverText;

    public static int life;
    public static int playerDamage = 1;

    public AudioSource music;
    public AudioSource key;
    public AudioSource enemyDamage;
    public AudioSource loss;
    public AudioSource gameOver;
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
        Move();       

        lifeCounter.text = "Life: " + life;

        if (life <= 0)
        {
            Manager3.inGame = false;
            lifeCounter.text = "";
            gameOverText.text = "GAME OVER";
            music.Stop();
            loss.Play();
            gameOver.Play();
            sadMusic.Play();
            Destroy(player);
        }
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

            if (Input.GetKey(KeyCode.S) && gameObject.transform.position.z >= -14f)
            {
                transform.position -= transform.forward * speed;
                key.Play();
            }

            if (Input.GetKey(KeyCode.D) && gameObject.transform.position.x <= 10)
            {
                transform.position += transform.right * speed;
                key.Play();
            }

            if (Input.GetKey(KeyCode.A) && gameObject.transform.position.x >= -6.5f)
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

            if (life <= 0)
            {
                Manager3.inGame = false;
                gameOverText.text = "GAME OVER";
            }
        }

        if (other.transform.tag == "BossBullet")
        {
            enemyDamage.Play();
            life = life - BossBullet.bossBulletDamage;            
        }
    }
}
