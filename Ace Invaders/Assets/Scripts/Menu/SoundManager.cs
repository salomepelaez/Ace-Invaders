using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    public AudioSource Music;
    public AudioSource buttonPressed;
    
    void Start()
    {
        Music.Play();
    }

    public void Button()
    {
        buttonPressed.Play();
    }
}
