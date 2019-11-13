using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager3 : MonoBehaviour
{
    public static bool inGame;
    public static int counterValue = 0;
    public TextMeshProUGUI score;
    public TextMeshProUGUI winnerText;

    public void Update()
    {
        if (FinalDialogue.active == true)
            inGame = true;

        score.text = "Score: " + counterValue;
    }
}
