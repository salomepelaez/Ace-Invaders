using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerController : MonoBehaviour
{
    float speed = 0.1f;
    public TextMeshProUGUI lifeCounter;
    public static int life;
    
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
        if (Messages.goAhead == true) 
        {
            Move();
            lifeCounter.text = "Life: " + life;

            if(life <= 0)
                lifeCounter.text = "";
        }       
            
    }

    void Move()
    {    
        if(Manager2.inGame == true)
        {
            if (Input.GetKey(KeyCode.W) && gameObject.transform.position.z <= 8f)
            {
                transform.position += transform.forward * speed;
            }

            if (Input.GetKey(KeyCode.S) && gameObject.transform.position.z >= -0.4f)
            {
                transform.position -= transform.forward * speed;
            }

            if (Input.GetKey(KeyCode.D) && gameObject.transform.position.x <= 6f)
            {
                transform.position += transform.right * speed;
            }

            if (Input.GetKey(KeyCode.A) && gameObject.transform.position.x >= -6f)
            {
                transform.position -= transform.right * speed;
            }

            Vector3 pos = new Vector3();
            if (pos.x >= -8.17f)
            {
                pos.x = -8.17f;
            }

            else if (pos.x >= 8.17f)
            {
                pos.x = 8.17f;
            }

            else if (pos.z >= -88.3)
            {
                pos.z = -88.3f;
            }

            else if (pos.z >= 88.3)
            {
                pos.z = 88.3f;
            }
        }  
        
    }    
    
    public void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            life = life - EnemyController.damage;
            
            if(life <= 0)
                Manager2.inGame = false;
        }
    }
}
