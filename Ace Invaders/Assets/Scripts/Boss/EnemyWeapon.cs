using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeapon : MonoBehaviour
{
    public AudioSource shoot;
    public GameObject bullet;
    float speed = 150f;

    void Awake()
    {
        transform.tag = "BossBullet";
    }

    void Start()
    {
        InvokeRepeating("DoDamage", 15f, 2f);
    }

    public void DoDamage()
    {
        if(FinalDialogue.active == true && Manager3.inGame == true)
        {
            Vector3 bulletDirection = new Vector3(0, 0, -1);
            GameObject instBullet = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
            instBullet.transform.Rotate(Vector3.left * 90);
            Rigidbody rigidbody = instBullet.GetComponent<Rigidbody>();
            rigidbody.AddForce(bulletDirection * speed);

            instBullet.AddComponent<CapsuleCollider>();
            instBullet.GetComponent<CapsuleCollider>().isTrigger = true;

            Destroy(this.gameObject, 10f);
            shoot.Play();
        }       
            
    }
}
