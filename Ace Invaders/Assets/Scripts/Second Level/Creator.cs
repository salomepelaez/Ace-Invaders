using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Creator : MonoBehaviour
{
    public GameObject enemy;
    GameObject bullet;
    
    private void Start()
    {                
        InvokeRepeating("Create", 1f, 5f);
    }
    
    void Create()
    {
        if (Messages.goAhead == true)
        {
            enemy = GameObject.CreatePrimitive(PrimitiveType.Cube);
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
}
