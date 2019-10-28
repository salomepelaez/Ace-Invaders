using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Dialogue : MonoBehaviour
{
    public TextMeshProUGUI intro;
   // public List<TextMeshProUGUI> story = new List<TextMeshProUGUI>(4);

    public void Story()
    {
        InvokeRepeating("Talk", 0, 1);
    }

    private string Talk()
    {
        intro.text = "ahgdhga";
        return intro.text;
    }
}
