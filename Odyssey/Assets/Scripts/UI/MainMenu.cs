using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenu : MonoBehaviour
{
    ////buttons we want to start on when opening each menu
    //public GameObject startMenuFirstButton, optionsFirstButton, optionsClosedButton;

    //private void OnEnable()
    //{
    //    //clear selected object
    //    EventSystem.current.SetSelectedGameObject(null);
    //    //set a new selected object which will be the start button
    //    EventSystem.current.SetSelectedGameObject(startMenuFirstButton);
    //    //playrain particle effect
    //    FindObjectOfType<ParticleManager>().Play("FXRain");
    //}

    //private void Update()
    //{
    //    if((Input.GetButtonDown("Submit")))
    //    {
    //        if(EventSystem.current.currentSelectedGameObject == startMenuFirstButton)
    //        {
    //            PlayGame();
    //        }
    //        else if (EventSystem.current.currentSelectedGameObject == startMenuFirstButton)
    //        {

    //        }
    //    }
    //}

    //above this is controller
    //-----------------------
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void QuitGame()
    {
        Debug.Log("QUIT!");
        Application.Quit();
    }

    


}
