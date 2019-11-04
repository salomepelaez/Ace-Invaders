using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    public GameObject next;

    private void Start()
    {
        next.SetActive(false);
    }

    private void Update()
    {
        if (Manager.winner == true)
        {
            next.SetActive(true);
        }
    }
}
