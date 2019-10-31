using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public static int life = 100;
    public GameObject bullet;
    //float bulletSpeed = 500f;

    public void Start()
    {        
        InvokeRepeating("Movement", 3f, 1f);
        //InvokeRepeating("DoDamage", 5f, 2f);

    }

    float speed = 0.2f;
    Behaviour behaviour;

    void Movement()
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

        if(Dialogue.active == true)
        {
            if (behaviour == Behaviour.Left && gameObject.transform.position.x >= -8.17f)
            {
                gameObject.transform.position -= transform.right * speed;
            }

            else if (behaviour == Behaviour.Right && gameObject.transform.position.x <= 8.17f)
            {
                gameObject.transform.position += transform.right * speed;

                if (gameObject.transform.position.x >= 8.17)
                {
                    behaviour = Behaviour.Left;
                }
            }
        }        
    }

    /*void DoDamage()
    {
        if(Dialogue.active == true)
        {
            GameObject instBullet = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
            instBullet.transform.Rotate(Vector3.left * 90);
            Rigidbody rigidbody = instBullet.GetComponent<Rigidbody>();
            rigidbody.AddForce(Vector3.forward * speed);

            Destroy(instBullet, 10f);
        }
    }*/
   
    enum Behaviour
    {
        Right, Left
    }
}
