using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    [SerializeField]
    private GameObject pausePanel;

    [SerializeField]
    private PlayerActions playerActions;

    private bool isPaused;

    void Start()
    {
        isPaused = false;

        playerActions = FindObjectOfType<PlayerActions>();
    }

    void Update()
    {
        if (playerActions.escape_Input)
        {
            if (isPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        Cursor.visible = true;

        Time.timeScale = 0f;

        pausePanel.SetActive(true);
        isPaused = true;
    }

    public void Resume()
    {
        Cursor.visible = false;

        Time.timeScale = 1f;

        pausePanel.SetActive(false);
        isPaused = false;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
