using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Achievement : MonoBehaviour
{
    [SerializeField]float timer;

    [SerializeField] GameObject achievementFX;
    [SerializeField] GameObject achievementImage;
    [SerializeField] GameObject achievementText;
    [SerializeField] GameObject achievementTuto;
    [SerializeField] GameObject tutoFrame;
    [SerializeField] GameObject tutoText;
    GameObject player;

    private void OnEnable()
    {
        player = GameObject.Find("Player");
        achievementFX.SetActive(true);
        achievementImage.SetActive(true);
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
            achievementFX.SetActive(false);
            achievementImage.SetActive(false);
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
