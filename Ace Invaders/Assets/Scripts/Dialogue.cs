using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI intro;
    public string[] phrases;
    int index;
        
    public void Awake()
    {
        intro = GameObject.Find("Dialogue").GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        First();
    }

    public void First()
    {
        intro.text = phrases[0];
    }

    IEnumerator PrintMessages()
    {
        foreach (char p in phrases[index].ToCharArray())
        {
            intro.text += p;
        }

        yield return new WaitForSeconds(0.2f);
    }

    public void NextSentence()
    {
        if(index < phrases.Length - 1)
        {
            index++;
            intro.text = "";

            StartCoroutine(PrintMessages());            
        }

        else
            intro.text = "";

        if (index == phrases.Length - 1)
        {
            gameObject.SetActive(false);
        }
    }

}

/*
 "You must find the way to save the city."
 "But you know..."
 "... sometimes the only way to be successful "
 "is fight!"
     */
