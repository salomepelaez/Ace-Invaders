using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    public static int weaponDamage = 25;
    int counter = 1;
    public static bool damage;

    void Update()
    {
        if(!damage)
            counter = counter + 1;

        //Debug.Log(counter);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            damage = true;
            Destroy(gameObject);
            damage = !damage;
            
        }
    }
}
