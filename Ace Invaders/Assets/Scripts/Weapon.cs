using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject bullet;

    void Update()
    {
        if(Input.GetKey((KeyCode.X)))
        {
            bullet = Instantiate(bullet) as GameObject;
        }
    }
}
