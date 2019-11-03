using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour
{
    public static bool inGame = true;
    public static bool winner;
    
    void Update()
    {
        Counter();
    }

    void Counter()
    {     
        int e = 0;
           
        foreach (Enemy enemy in Transform.FindObjectsOfType<Enemy>())
        {
            e = e + 1;

            if(e == 1)
                e = 0;

            if(e == 0)
            {
                //inGame = false;
                winner = true;
            }

            Debug.Log(e);
        }
    }
}
