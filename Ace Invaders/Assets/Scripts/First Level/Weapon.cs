﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public AudioSource Shoot;
    public GameObject bullet;
    float speed = 800f;

    void Awake()
    {
        transform.tag = "Bullet";
    }

    void Update()
    {
        if(Manager.inGame == true)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                GameObject instBullet = Instantiate(bullet, transform.position, Quaternion.identity) as GameObject;
                instBullet.transform.Rotate(Vector3.left * 90);
                Rigidbody rigidbody = instBullet.GetComponent<Rigidbody>();
                rigidbody.AddForce(Vector3.forward * speed);

                PlaySound();

                Destroy(instBullet, 5f);
            }

            if(Input.GetKeyDown(KeyCode.F))
            {
                StartCoroutine("GoSlow");
            }
        }        
    }   

    void PlaySound()
    {
        Shoot.Play();
    }

    IEnumerator GoSlow()
    {
        Enemy.speed = 0;

        yield return new WaitForSeconds(3f);

        Enemy.speed = 3f;
    }
}
