using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class FadeText : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI text;
    Color textColor;
    bool transitionScreenDark;
    bool transitionScreenTransparent;
    public float transitionSpeed;
    float fadeInTimer;
    float fadeOutTimer;
    [SerializeField] float timeTillFadeIn;
    [SerializeField] float timeTillFadeOut;

    private void OnEnable()
    {
        fadeInTimer = timeTillFadeIn;
        fadeOutTimer = timeTillFadeOut;
        transitionScreenTransparent = false;
    }
    private void Start()
    {
        
        //get the image
        text = GetComponent<TextMeshProUGUI>();
        //set color to image color
        textColor = text.color;
    }

    private void Update()
    {
        //check timer if zero start transitioning
        if (fadeInTimer <= 0 && !transitionScreenDark && !transitionScreenTransparent)
        {
            transitionScreenDark = true;
        }
        else
        {
            fadeInTimer -= Time.deltaTime;
        }

        Transition();

    }

    private void Transition()
    {
        if (transitionScreenDark)
        {
            ScreenTransitionDark();
        }

        if (transitionScreenTransparent && fadeOutTimer <= 0)
        {
            ScreenTransitionTransparent();
        }
        else if (transitionScreenTransparent)
        {
            fadeOutTimer -= Time.deltaTime;
        }

    }

    private void ScreenTransitionDark()
    {

        textColor.a += transitionSpeed * Time.deltaTime;
        text.color = textColor;

        if (text.color.a >= 1)
        {
            transitionScreenTransparent = true;
            transitionScreenDark = false;
        }
    }

    private void ScreenTransitionTransparent()
    {

        textColor.a -= transitionSpeed * Time.deltaTime;
        text.color = textColor;

        if (text.color.a <= 0)
        {
            
            

        }
    }

}
