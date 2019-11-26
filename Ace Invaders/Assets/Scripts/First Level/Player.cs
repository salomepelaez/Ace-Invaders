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
    private Vector2 direction;

    private int life = 3;

    private float speed = 3f;

    void Update()
    {
        if(Dialogue.active == true)
        {
            if(Manager.inGame == true)
            {
                MoveWithKeyBoard();
                direction = joystick.Direction * speed * Time.deltaTime;
                transform.position += new Vector3(direction.x, 0f, direction.y);
            }

            lifeCounter.text = "Life: " + life;

            if(life <= 0)
                lifeCounter.text = "";
        }

        LimitateAxis();
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

    private void LimitateAxis()
    {
        if (gameObject.transform.position.z >= -72f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -72f);
        }

        else if (gameObject.transform.position.z <= -80f)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -80f);
        }

        else if (gameObject.transform.position.x >= 8.17f)
        {
            transform.position = new Vector3(8.17f, transform.position.y, transform.position.z);
        }

        else if (gameObject.transform.position.x <= -8.17f)
        {
            transform.position = new Vector3(-8.17f, transform.position.y, transform.position.z);
        }
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
