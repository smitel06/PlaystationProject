using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeImage : MonoBehaviour
{

    [SerializeField] Image image;
    Color imageColor;
    bool transitionScreenDark;
    bool transitionScreenTransparent;
    public float transitionSpeed;
    [SerializeField] float timeTillFadeIn;
    [SerializeField] float timeTillFadeOut;

    private void Start()
    {
        //get the image
        image = GetComponent<Image>();
        //set color to image color
        imageColor = image.color;
    }

    private void Update()
    {
        //check timer if zero start transitioning
        if(timeTillFadeIn <= 0 && !transitionScreenDark && !transitionScreenTransparent)
        {
            transitionScreenDark = true;
        }
        else
        {
            timeTillFadeIn -= Time.deltaTime; 
        }

        Transition();

    }

    private void Transition()
    {
        if (transitionScreenDark)
        {
            ScreenTransitionDark();
        }
        
        if (transitionScreenTransparent && timeTillFadeOut <= 0)
        {
            ScreenTransitionTransparent();
        }
        else if(transitionScreenTransparent)
        {
            timeTillFadeOut -= Time.deltaTime;
        }

    }

    private void ScreenTransitionDark()
    {

        imageColor.a += transitionSpeed * Time.deltaTime;
        image.color = imageColor;

        if (image.color.a >= 1)
        {
            transitionScreenTransparent = true;
            transitionScreenDark = false;
        }
    }

    private void ScreenTransitionTransparent()
    {
        
        imageColor.a -= transitionSpeed * Time.deltaTime;
        image.color = imageColor;

        if (image.color.a <= 0)
        {
            imageColor.a = 0;
            
        }
    }

}
