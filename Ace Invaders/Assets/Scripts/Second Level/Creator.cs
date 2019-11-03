using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator : MonoBehaviour
{
    public GameObject enemy;
    GameObject bullet;

    bool damage;

    private void Start()
    {                
        InvokeRepeating("Create", 1f, 5f);
    }

    void Update()
    {
        Counter();
    }
    
    void Create()
    {
        if (Messages.goAhead == true)
        {
            enemy = GameObject.CreatePrimitive(PrimitiveType.Cube);
            enemy.AddComponent<BoxCollider>();
            enemy.AddComponent<Rigidbody>();
            Vector3 pos = new Vector3();
            pos.x = Random.Range(-4.74f, 5.37f);
            pos.y = 1.66f;
            pos.z = 9.65f;

            enemy.transform.position = pos;
            
            switch(Random.Range(0, 2))
            {
                case 0:
                    enemy.AddComponent<Enemy1>();
                    break;

                case 1:
                    enemy.AddComponent<Enemy2>();
                    break;
            }
        }
    }

    void Counter()
    {
        int e1 = 0;
        int e2 = 0;

        foreach (Enemy1 enemy1 in Transform.FindObjectsOfType<Enemy1>())
        {
            e1 = e1 + 1;
        }

        foreach (Enemy2 enemy2 in Transform.FindObjectsOfType<Enemy2>())
        {
            e2 = e2 + 1;
        }
        
        if(e1 >= 2 && e2 == 5)
            CancelInvoke();

        else if(e1 <= 1 && e2 <= 1)
            Debug.Log("lol");
    }
}
