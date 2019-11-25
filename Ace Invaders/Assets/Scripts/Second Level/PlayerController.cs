using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    private float speed = 3f;

    public TextMeshProUGUI lifeCounter;
    public TextMeshProUGUI gameOver;
    
    public int life;

    public AudioSource music;
    public AudioSource key;
    public AudioSource enemyDamage;
    public AudioSource loss;
    public AudioSource gameOverSound;
    public AudioSource sadMusic;

    public Joystick joystick;
    private Vector2 direction;

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
            direction = joystick.Direction * speed * Time.deltaTime;
            transform.position += new Vector3(direction.x, 0f, direction.y);
        }       

        lifeCounter.text = "Life: " + life;

        if (life <= 0)
        {
            lifeCounter.text = "";
            gameOver.text = "You died!";            
        }   
    }

    void Move()
    {    
        if(Manager2.inGame == true)
        {
            if (Input.GetKey(KeyCode.W) && gameObject.transform.position.z <= 8f)
            {
                transform.position += transform.forward * speed * Time.deltaTime;
                key.Play();
            }

            if (Input.GetKey(KeyCode.S) && gameObject.transform.position.z >= -0.4f)
            {
                transform.position -= transform.forward * speed * Time.deltaTime;
                key.Play();
            }

            if (Input.GetKey(KeyCode.D) && gameObject.transform.position.x <= 6f)
            {
                transform.position += transform.right * speed * Time.deltaTime;
                key.Play();
            }

            if (Input.GetKey(KeyCode.A) && gameObject.transform.position.x >= -6f)
            {
                transform.position -= transform.right * speed * Time.deltaTime;
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
                Manager2.inGame = false;
                music.Stop();
                loss.Play();
                gameOverSound.Play();
                sadMusic.Play();
            }
        }
    }

    public void MoveUp()
    {
        if (Messages.goAhead == true && Input.touchCount > 0)
        {
            if (gameObject.transform.position.z <= 8f)
            {
                transform.position += transform.forward * speed * Time.deltaTime;
                key.Play();
            }
        }
    }

    public void MoveDown()
    {
        if (Messages.goAhead == true && Input.touchCount > 0)
        {
            if (gameObject.transform.position.z >= -0.4f)
            {
                transform.position -= transform.forward * speed * Time.deltaTime;
                key.Play();
            }
        }
    }

    public void MoveLeft()
    {
        if (Messages.goAhead == true && Input.touchCount > 0)
        {
            if (gameObject.transform.position.x <= 6f)
            {
                transform.position -= transform.right * speed * Time.deltaTime;
                key.Play();
            }
        }
    }

    public void MoveRight()
    {
        if (Messages.goAhead == true && Input.touchCount > 0)
        {
            if (gameObject.transform.position.x >= -6f)
            {
                transform.position += transform.right * speed * Time.deltaTime;
                key.Play();
            }
        }
    }
}
