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

    public void Boss()
    {
        SceneManager.LoadScene("Boss");
    }

}
