using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Achievement : MonoBehaviour
{
    float timer;
    [SerializeField] TextMeshProUGUI textMesh;

    private void OnEnable()
    {
        timer = 5;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timer <= 0)
        {
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
