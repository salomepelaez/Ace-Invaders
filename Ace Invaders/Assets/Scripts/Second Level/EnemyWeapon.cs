using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    /*public GameObject bullet;
    float speed = 800f;

    void Awake()
    {
        transform.tag = "Bullet";
    }

    void Start()
    {
        InvokeRepeating("DoDamage", 2f, 2f);                
    }   

    void DoDamage()
    {
        GameObject instBullet = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
        instBullet.transform.Rotate(Vector3.up * 90);
        Rigidbody rigidbody = instBullet.GetComponent<Rigidbody>();
        rigidbody.AddForce(Vector3.forward * speed);

        Destroy(instBullet, 3f);
    }*/
}
