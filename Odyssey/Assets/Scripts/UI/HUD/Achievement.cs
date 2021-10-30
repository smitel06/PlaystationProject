using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Achievement : MonoBehaviour
{
    [SerializeField]float timer;
    [SerializeField] TextMeshProUGUI textMesh;
    [SerializeField] GameObject textObject;
    [SerializeField] GameObject imageObject;

    private void OnEnable()
    {
        timer = 8;
        textObject.SetActive(true);
        imageObject.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
            textObject.SetActive(false);
            imageObject.SetActive(false);
            this.gameObject.SetActive(false);

        }
        else
            timer -= Time.deltaTime;
    }

    public void setText(string textToSet)
    {
        textMesh.text = textToSet;
    }
}
