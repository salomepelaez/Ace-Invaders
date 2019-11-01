using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Messages : MonoBehaviour
{
    public TextMeshProUGUI continueB;

    public GameObject continueButton;

    public static bool goAhead;

    private void Awake()
    {
        continueB = GameObject.Find("ContinueB").GetComponent<TextMeshProUGUI>();
    }

    public void Continue()
    {
        continueB.text = "";
        continueButton.SetActive(false);

        goAhead = true;
    }
}
