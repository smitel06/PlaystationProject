using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Achievement : MonoBehaviour
{
    float timer;
    [SerializeField]float timerReset;

    [SerializeField] GameObject achievementFX;
    [SerializeField] GameObject achievementImage;
    [SerializeField] GameObject achievementText;
    [SerializeField] GameObject achievementTuto;
    [SerializeField] GameObject tutoFrame;
    [SerializeField] GameObject tutoText;
    [SerializeField] string SoundEffect;
    GameObject player;

    
    private void OnEnable()
    {
        AudioManager.instance.Play(SoundEffect);
        timer = timerReset;
        player = GameObject.Find("Player");
        if (achievementFX != null)
            achievementFX.SetActive(true);
        if (achievementImage != null)
            achievementImage.SetActive(true);
        if(achievementText != null)
            achievementText.SetActive(true);
        achievementTuto.SetActive(true);
        tutoFrame.SetActive(true);
        tutoText.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            player.GetComponent<PlayerController>().pausePlayer = false;
            if(achievementFX != null)
                achievementFX.SetActive(false);
            if (achievementImage != null)
                achievementImage.SetActive(false);
            if (achievementText != null)
                achievementText.SetActive(false);
            achievementTuto.SetActive(false);
            tutoFrame.SetActive(false);
            tutoText.SetActive(false);
            gameObject.SetActive(false);
        }
        else
            timer -= Time.deltaTime;

        
    }

    
}
