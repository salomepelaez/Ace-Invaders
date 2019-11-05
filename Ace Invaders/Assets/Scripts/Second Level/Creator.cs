using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator : MonoBehaviour
{
    public GameObject enemy;
    bool damage;

    private void Start()
    {      
        if(Manager2.inGame == true)          
        {
            InvokeRepeating("Create1", 1f, 2f);
            InvokeRepeating("Create2", 1f, 10f);  
        }          
    }
    
    void Create1()
    {
        if (Messages.goAhead == true)
        {
            enemy = GameObject.CreatePrimitive(PrimitiveType.Cube);
            enemy.AddComponent<Enemy1>();
            enemy.layer = 9;
            enemy.AddComponent<BoxCollider>();
            enemy.AddComponent<Rigidbody>();
            Vector3 pos = new Vector3();
            pos.x = Random.Range(-4.74f, 5.37f);
            pos.y = 1.66f;
            pos.z = 9.65f;

            enemy.transform.position = pos;
        }
    }

    void Create2()
    {
        if (Messages.goAhead == true)
        {
            enemy = GameObject.CreatePrimitive(PrimitiveType.Cube);
            enemy.AddComponent<Enemy2>();
            enemy.layer = 9;
            enemy.AddComponent<BoxCollider>();
            enemy.AddComponent<Rigidbody>();
            Vector3 pos = new Vector3();
            pos.x = Random.Range(-4.74f, 5.37f);
            pos.y = 1.66f;
            pos.z = 3.5f;

            enemy.transform.position = pos;
        }
    }
}
