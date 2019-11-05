using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }

        if(gameObject.transform.position.z >= 9f)
            Destroy(this.gameObject);
    }
}
