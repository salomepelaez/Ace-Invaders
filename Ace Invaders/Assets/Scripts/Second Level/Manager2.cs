using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager2 : MonoBehaviour
{
    public static bool inGame;
    public static bool winner;
    public static int counterValue = 0;
    public GameObject next;

    void Start()
    {
        next.SetActive(false);
    }
    

    public void Update()
    {
        if(counterValue == 100)
        {
            winner = true;
            next.SetActive(true);
            Debug.Log(winner);
        }
    }
}
