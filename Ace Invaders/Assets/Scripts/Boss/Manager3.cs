using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager3 : MonoBehaviour
{
    public static bool inGame;
    public static int counterValue;

    public TextMeshProUGUI score;

    private void Start()
    {
        counterValue = 0;        
    }

    public void Update()
    {
        if (FinalDialogue.active == true)
        {
            inGame = true;
        }

        score.text = "Score: " + counterValue;
    }
}
