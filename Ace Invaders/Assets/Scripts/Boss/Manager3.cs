using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager3 : MonoBehaviour
{
    public static bool inGame = true;
    public static bool winner;
    public static int counterValue = 0;
    public TextMeshProUGUI score;
    public TextMeshProUGUI gameOver;
    
    public void Update()
    {
        score.text = "Score: " + counterValue;

        if(inGame == false)
            gameOver.text = "GAME OVER";
    }
}
