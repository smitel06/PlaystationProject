using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dissolve : MonoBehaviour
{
    [SerializeField] float waitTime;
    [SerializeField] float Timer;
    [SerializeField] Shader dissolve;

    private void Update()
    {
        //after animation is done dissolve character
        if (Timer >= waitTime)
        {
            CreateShader();
        }
        else
            Timer += Time.deltaTime;

    }

    void CreateShader()
    {

        // Create a material with dissolve shader
        Material material = new Material(dissolve);
        material.color = Color.red;

        // assign the material to the renderer
        GetComponent<Renderer>().material = material;
        
    }



}
