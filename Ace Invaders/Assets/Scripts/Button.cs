using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Button : MonoBehaviour
{
    private void Start()
    {
        gameObject.SetActive(false);
    }

    private void Update()
    {
        Next();
    }

    private void Next()
    {
        if(Dialogue.nextSentence == true)
        {
            gameObject.SetActive(true);
        }
    }
}
