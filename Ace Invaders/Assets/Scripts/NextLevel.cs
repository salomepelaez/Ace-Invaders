using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextLevel : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void FirstLevel()
    {
        if (Enemy.counter == 3)
        {
            gameObject.SetActive(true);
        }
    }
}
