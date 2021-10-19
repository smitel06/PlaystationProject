using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuButtonController : MonoBehaviour 
{

	// Use this for initialization
	public int index;
	[SerializeField] bool keyDown;
	[SerializeField] int maxIndex; //changed to read only as i will use code to change depending on menu
	public AudioSource audioSource;
    [SerializeField] bool isHorizontal;


    //I am adding new stuff between these lines
    //-----------------------------------------
    public MenuButton[] buttons;
    private void OnEnable()
    {
        EventSystem.current.SetSelectedGameObject(null);
        //collect all buttons 
        buttons = this.GetComponentsInChildren<MenuButton>();
        maxIndex = buttons.Length - 1;
        //set index of each button
        int i = 0;
        foreach(MenuButton button in buttons)
        {
            button.thisIndex = i;
            i++;
        }
    }

    //-----------------------------------------

    void Start () 
    {
		audioSource = GetComponent<AudioSource>();

	}
	
	// Update is called once per frame
	void Update ()
    {
        if (!isHorizontal)
        {
            if (Input.GetAxis("Vertical") != 0)
            {
                if (!keyDown)
                {
                    if (Input.GetAxis("Vertical") < 0)
                    {
                        if (index < maxIndex)
                        {
                            //this clears the last button 
                            EventSystem.current.SetSelectedGameObject(null);
                            index++;
                        }
                        else
                        {
                            index = 0;
                        }
                    }
                    else if (Input.GetAxis("Vertical") > 0)
                    {
                        if (index > 0)
                        {
                            //this clears the last button 
                            EventSystem.current.SetSelectedGameObject(null);
                            index--;
                        }
                        else
                        {
                            index = maxIndex;
                        }
                    }
                    keyDown = true;
                }
            }
            else
            {
                keyDown = false;
            }
        }
        else if(isHorizontal) //if menu has horizontal set up do this
        {
            if (Input.GetAxis("Vertical") < 0)
            {
                //this clears the last button 
                EventSystem.current.SetSelectedGameObject(null);
                index = maxIndex;

            }
            else if (Input.GetAxis("Horizontal") != 0)
            {
                if (!keyDown)
                {
                    if (Input.GetAxis("Horizontal") > 0)
                    {
                        if (index < maxIndex)
                        {
                            //this clears the last button 
                            EventSystem.current.SetSelectedGameObject(null);
                            index++;
                        }
                        else
                        {
                            index = 0;
                        }
                    }
                    else if (Input.GetAxis("Horizontal") < 0)
                    {
                        if (index > 0)
                        {
                            //this clears the last button 
                            EventSystem.current.SetSelectedGameObject(null);
                            index--;
                        }
                        else
                        {
                            index = maxIndex;
                        }
                    }
                    keyDown = true;
                }
            }
            else
            {
                keyDown = false;
            }
        }


        //I am also adding in other things below this line
        //------------------------------------------------
        //these select the buttons to highlight
        selectButton();
    }

    private void selectButton()
    {
        //will need a for loop to iterate and check every button
        foreach(MenuButton button in buttons)
        {
            //check if indexes match
            if (index == button.thisIndex)
            {
                EventSystem.current.SetSelectedGameObject(button.gameObject);
            }
        }

    }
}
