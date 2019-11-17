using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public AudioSource key;
    public AudioSource enemyDamage;

    public TextMeshProUGUI lifeCounter;

    public Joystick joystick;

    public static int life = 3;

    float speed = 3f;
    float horizontalMove = 0f;

    void Update()
    {
        if(Dialogue.active == true)
        {
            if(Manager.inGame == true)
            {
                MoveWithKeyBoard();
                TouchMovement();
            }

            lifeCounter.text = "Life: " + life;

            if(life <= 0)
                lifeCounter.text = "";
        }        
    }

    void MoveWithKeyBoard()
    {      
        if(Manager.inGame == true)
        {
            if (Input.GetKey(KeyCode.W) && gameObject.transform.position.z <= -72f)
            {
                transform.position += transform.forward * speed *  Time.deltaTime;
                key.Play();
            }

            if (Input.GetKey(KeyCode.S) && gameObject.transform.position.z >= -80f)
            {
                transform.position -= transform.forward * speed *  Time.deltaTime;
                key.Play();
            }

            if (Input.GetKey(KeyCode.D) && gameObject.transform.position.x <= 8.17f)
            {
                transform.position += transform.right * speed *  Time.deltaTime;
                key.Play();
            }

            if (Input.GetKey(KeyCode.A) && gameObject.transform.position.x >= -8.17f)
            {
                transform.position -= transform.right * speed *  Time.deltaTime;
                key.Play();
            }
        }
    }

    void TouchMovement()
    {
        horizontalMove = joystick.Horizontal * speed;
    }
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            enemyDamage.Play();
            life = life - Enemy.damage;
            Debug.Log(life);

            if(life <= 0)
                Manager.inGame = false;
        }
    }
}
