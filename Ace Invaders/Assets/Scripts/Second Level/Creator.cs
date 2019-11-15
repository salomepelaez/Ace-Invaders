using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator : MonoBehaviour
{
    public GameObject e;
    public GameObject e2;
    bool damage;

    private void Start()
    {     
        InvokeRepeating("Create1", 1f, 2f);
        InvokeRepeating("Create2", 1f, 10f);                    
    }
    
    void Create1()
    {
        if(Manager2.inGame == true)          
        {
            if (Messages.goAhead == true)
            {
                GameObject enemy = Instantiate(e, Vector3.zero, Quaternion.identity);
                enemy.AddComponent<Enemy1>();
                enemy.layer = 9;
                enemy.AddComponent<BoxCollider>();
                enemy.GetComponent<BoxCollider>().isTrigger = true;
                enemy.AddComponent<Rigidbody>();
                Vector3 pos = new Vector3();
                pos.x = Random.Range(-4.74f, 5.37f);
                pos.y = 1.66f;
                pos.z = 9.65f;

                enemy.transform.position = pos;
            }
        }
    }

    void Create2()
    {
        if(Manager2.inGame == true)          
        {
            if (Messages.goAhead == true)
            {
                GameObject enemy = Instantiate(e2, Vector3.zero, Quaternion.identity);
                enemy.AddComponent<Enemy2>();
                enemy.layer = 9;
                enemy.AddComponent<BoxCollider>();
                enemy.GetComponent<BoxCollider>().isTrigger = true;
                enemy.AddComponent<Rigidbody>();
                Vector3 pos = new Vector3();
                pos.x = Random.Range(-4.74f, 5.37f);
                pos.y = 1.66f;
                pos.z = 3.5f;

                enemy.transform.position = pos;
            }
        }
    }
}
