using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI intro;
    public string[] phrases;
    int index;

    public static bool active;

    public GameObject button;
    public GameObject buttonShoot;
    public GameObject buttonFreeze;

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

    private void Update()
    {
        if(Manager.inGame == true)
        {
            buttonFreeze.SetActive(true);
            buttonShoot.SetActive(true);
        }

        if (Manager.inGame == false)
        {
            buttonFreeze.SetActive(false);
            buttonShoot.SetActive(false);
        }
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
            button.SetActive(false);  
            intro.text = ""; 

            active = true;
            Manager.inGame = true;                               
        }        
    }

   
}

