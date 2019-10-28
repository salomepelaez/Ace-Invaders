using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Dialogue : MonoBehaviour
{
    public Text intro;
    // public List<TextMeshProUGUI> story = new List<TextMeshProUGUI>(4);

    public void Awake()
    {
        intro = GameObject.Find("Dialogue").GetComponent<Text>();
    }
    public void Story()
    {
        StartCoroutine("PrintMessages");
    }

    IEnumerator PrintMessages()
    {
        intro.text = "You must find the way to save the city.";
   
        yield return new WaitForSeconds(5);

        intro.text = "But you know...";

        yield return new WaitForSeconds(5);

        intro.text = "... sometimes the only way to be successful ";

        yield return new WaitForSeconds(5);

        intro.text = "is fight!";

        yield return new WaitForSeconds(5);

        intro.text = "";
    }
}
