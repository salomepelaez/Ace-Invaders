using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Manager2 : MonoBehaviour
{
    public static bool inGame = true;
    public static bool winner;
    public static int counterValue;
    public TextMeshProUGUI score;

    private void Start()
    {
        counterValue = 0;    
    }

    public void Update()
    {
        score.text = "Score: " + counterValue;
        if(counterValue == 1000)
        {
            winner = true;
            inGame = false;
            SceneManager.LoadScene("Boss");
        }
    }
}
