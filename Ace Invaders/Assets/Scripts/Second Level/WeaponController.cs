using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponController : MonoBehaviour
{
    public AudioSource shoot;
    public GameObject bullet;
    float speed = 800f;

    void Awake()
    {
        transform.tag = "Bullet";
    }

    public void Update()
    {
        if (Messages.goAhead == true)  
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                GameObject instBullet = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
                instBullet.transform.Rotate(Vector3.left * 90);
                Rigidbody rigidbody = instBullet.GetComponent<Rigidbody>();
                rigidbody.AddForce(Vector3.forward * speed);

                shoot.Play();

                Destroy(instBullet, 1f);
            }
        }
    }   
}
