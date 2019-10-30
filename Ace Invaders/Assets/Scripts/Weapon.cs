using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject laser;

    private void Start()
    {
        laser.SetActive(false);
    }

    private void OnMouseDown()
    {
        laser.SetActive(true);
    }
}
