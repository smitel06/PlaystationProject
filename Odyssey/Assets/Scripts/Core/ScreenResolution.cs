using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenResolution : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //set resolution on load
        Screen.SetResolution(1920, 1080, true);
    }

   
}
