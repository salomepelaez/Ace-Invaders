using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public AudioSource shoot;
    public GameObject bullet;
    float speed = 800f;

    void Awake()
    {
        transform.tag = "BossBullet";
    }

    void Start()
    {
        InvokeRepeating("DoDamage", 2f, 3f);
    }

    public void DoDamage()
    {
        if(Manager3.inGame == true)
        {
            Vector3 bulletDirection = new Vector3(0, 0, -1);
            GameObject instBullet = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
            instBullet.transform.Rotate(Vector3.left * 90);
            Rigidbody rigidbody = instBullet.GetComponent<Rigidbody>();
            rigidbody.AddForce(bulletDirection * speed);

            instBullet.AddComponent<CapsuleCollider>();
            instBullet.GetComponent<CapsuleCollider>().isTrigger = true;

            Destroy(instBullet, 1f);
            shoot.Play();
        }       
            
    }
}
