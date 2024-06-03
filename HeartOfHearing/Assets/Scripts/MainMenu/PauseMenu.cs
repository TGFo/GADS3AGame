using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    bool paused = false;
    public GameObject pauseMenuPanel;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(paused)
            {
               ResumeGame();
            }
            else
            {
                paused = true;
                Time.timeScale = 0f;
                pauseMenuPanel.SetActive(true);
            }
        }
    }
    public void ResumeGame()
    {
        paused = false;
        Time.timeScale = 1.0f;
        pauseMenuPanel.SetActive(false);
    }
}
