using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;

    public GameObject pauseMenuUI;


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetButtonDown("Pause"))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }

            FindObjectOfType<AudioManager>().Play("UI_Pause");
        }
    }

    public void Resume ()
    {
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f; //To reset time to normal
        GameIsPaused = false;
    }

    void Pause ()
    {
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f; //To Freeze time in game
        GameIsPaused = true;
    }

    public void LoadOptions()
    {
        Debug.Log("Loading Options...");
    }

    public void LoadMenu()
    {
        //Debug.Log("Loading menu...");
        Time.timeScale = 1f; //To stop being on Pause
        SceneManager.LoadScene("MainMenu");
    }

 
    public void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }

    public void SettingsMenuOn()
    {
        Debug.Log("working");
    }

    
}
