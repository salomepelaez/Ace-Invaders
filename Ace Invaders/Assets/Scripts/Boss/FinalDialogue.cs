using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinalDialogue : MonoBehaviour
{
    public TextMeshProUGUI congratulations;
    public string[] phrases;
    int index;

    public static bool active;

    public GameObject button;

    private void Start()
    {
        First();
    }

    public void First()
    {
        congratulations.text = phrases[0];
    }

    IEnumerator PrintMessages()
    {
        foreach (char p in phrases[index].ToCharArray())
        {
            congratulations.text += p;
        }

        yield return new WaitForSeconds(0.2f);
    }

    public void NextSentence()
    {
        if (index < phrases.Length - 1)
        {
            index++;
            congratulations.text = "";

            StartCoroutine(PrintMessages());
        }

        else
            congratulations.text = "";

        if (index == phrases.Length - 1)
        {
            button.SetActive(false);
            congratulations.text = "";

            active = true;
            Manager3.inGame = true;
        }
    }
}
