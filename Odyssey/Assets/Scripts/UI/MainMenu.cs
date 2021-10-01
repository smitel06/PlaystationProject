using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    private void Update()
    {
        checkForInput();
    }

    //Input with controller goes underneath here
    void checkForInput()
    {
        
        if (Input.GetButtonDown("Submit"))
        {
            //this is A or X button
        }
        else if (Input.GetButtonDown("Cancel"))
        {
            //this is A or X button
        }

    }

}
