using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{
    public AudioSource key;
    public AudioSource enemyDamage;

    public TextMeshProUGUI lifeCounter;

    public static int life = 3;

    float speed = 3f;

    void Update()
    {
        if(Dialogue.active == true)
        {
            if(Manager.inGame == true)
            {
                Move();
            }

            lifeCounter.text = "Life: " + life;

            if(life <= 0)
                lifeCounter.text = "";
        }        
    }

    void Move()
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
