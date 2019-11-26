using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController2 : MonoBehaviour
{
    public GameObject player;
    public GameObject buttonShoot;
    public GameObject buttonFreeze;

    public TextMeshProUGUI lifeCounter;
    public TextMeshProUGUI gameOverText;

    private int life;
    public static int playerDamage = 1;

    public AudioSource music;
    public AudioSource key;
    public AudioSource enemyDamage;
    public AudioSource loss;
    public AudioSource gameOver;
    public AudioSource sadMusic;

    public Joystick joystick;
    private Vector2 direction;

    private float speed = 3f;
    
    void Start()
    {
        music.Play();
        life = 3;
    }

    void Awake()
    {
        gameObject.layer = 10;
        transform.tag = "Player";

        buttonFreeze.SetActive(true);
        buttonShoot.SetActive(true);
    }

    void Update()
    {
        Move();
        direction = joystick.Direction * speed * Time.deltaTime;
        transform.position += new Vector3(direction.x, 0f, direction.y);

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

        LimitateAxis();
    }

    void Move()
    {    
        if(Manager3.inGame == true)
        {
            if (Input.GetKey(KeyCode.W) && gameObject.transform.position.z <= -8f)
            {
                transform.position += transform.forward * speed * Time.deltaTime;
                key.Play();
            }

            if (Input.GetKey(KeyCode.S) && gameObject.transform.position.z >= -14f)
            {
                transform.position -= transform.forward * speed * Time.deltaTime;
                key.Play();
            }

            if (Input.GetKey(KeyCode.D) && gameObject.transform.position.x <= 10)
            {
                transform.position += transform.right * speed * Time.deltaTime;
                key.Play();
            }

            if (Input.GetKey(KeyCode.A) && gameObject.transform.position.x >= -6.5f)
            {
                transform.position -= transform.right * speed * Time.deltaTime;
                key.Play();
            }
        }
    }

    private void LimitateAxis()
    {
        if (gameObject.transform.position.z >= -8f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -8f);
        }

        else if (gameObject.transform.position.z <= -14f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -14f);
        }

        else if (gameObject.transform.position.x >= 10f)
        {
            transform.position = new Vector3(10f, transform.position.y, transform.position.z);
        }

        else if (gameObject.transform.position.x <= -6.5f)
        {
            transform.position = new Vector3(-6.5f, transform.position.y, transform.position.z);
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
                buttonFreeze.SetActive(false);
                buttonShoot.SetActive(false);
            }
        }

        if (other.transform.tag == "BossBullet")
        {
            enemyDamage.Play();
            life = life - BossBullet.bossBulletDamage;            
        }
    }
}
