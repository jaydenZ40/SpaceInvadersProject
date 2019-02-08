using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel;
    bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            TogglePause();
        }
    }
    public void TogglePause()
    {
        if (isPaused)
        {
            pausePanel.SetActive(false);
        }
        else pausePanel.SetActive(true);
        isPaused = !isPaused;
        Time.timeScale = isPaused ? 0 : 1;
    }
}
