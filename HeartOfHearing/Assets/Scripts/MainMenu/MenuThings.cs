using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuThings : MonoBehaviour
{
    public string firstLevelName;
    public void StartGame()
    {
        SceneManager.LoadScene(firstLevelName);
    }
    public void ToMainMenu()
    {
        Time.timeScale = 1.0f;
        SceneManager.LoadScene("MainMenu");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
