using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Builder : MonoBehaviour
{    
    GameObject enemy;

    void Start()
    {        
       Invoke("Creator", time);       
    }

    void Update()
    {
        Movement();
    }

    float speed = 0.2f;
    float time = 10f;
    void Creator()
    {
        Vector3 position = new Vector3();
        enemy = GameObject.CreatePrimitive(PrimitiveType.Cube);  

        enemy.AddComponent<Rigidbody>();

        position.x = Random.Range(-5.56f, 5.56f);
        position.y = 2;
        position.z = 9.5f;
        enemy.transform.position = position;
       
        time--;
        Debug.Log(time);       
    }

    void Movement()
    {
        if(enemy != null)
        {
            enemy.transform.position += transform.forward * speed;
            speed++;
        }
    }
}


