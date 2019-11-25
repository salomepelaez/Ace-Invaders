using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Manager3 : MonoBehaviour
{
    public static bool inGame;
    public static int counterValue;

    public TextMeshProUGUI score;
    public TextMeshProUGUI winnerText;

    public GameObject buttonShoot;
    public GameObject buttonFreeze;

    private void Start()
    {
        counterValue = 0;        
    }

    public void Update()
    {
        if (FinalDialogue.active == true)
        {
            inGame = true;
            buttonFreeze.SetActive(true);
            buttonShoot.SetActive(true);
        }

        score.text = "Score: " + counterValue;

        if (Manager3.inGame == false)
        {
            buttonFreeze.SetActive(false);
            buttonShoot.SetActive(false);
        }
    }
}
