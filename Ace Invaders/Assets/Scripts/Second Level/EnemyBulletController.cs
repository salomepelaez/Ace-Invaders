using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletController : MonoBehaviour
{
    float speed = 800;

    void Update()
    {
        transform.position -= transform.forward * speed * Time.deltaTime;
        Destroy(gameObject, 3f);
    }
}
