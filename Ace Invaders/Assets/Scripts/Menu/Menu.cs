using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("Game1");
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Menu");

    }

    public void NextLevel()
    {
        SceneManager.LoadScene("Game2");        
    }
    
    public void Restart()
    {
        SceneManager.LoadScene("Game1");

        if(Manager.inGame == false)
            Manager.inGame = true;
    }

    public void Restart2()
    {
        SceneManager.LoadScene("Game2");

        if(Manager2.inGame == false)
            Manager2.inGame = true;

        if (Messages.goAhead == true)
            Messages.goAhead = false;
    }

    public void RestartBoss()
    {
        SceneManager.LoadScene("Boss");
        if (Manager3.inGame == false)
            Manager3.inGame = true;            
        
        if(Dialogue.active == true)
            FinalDialogue.active = false;
        
    }
}
