using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBlast : MonoBehaviour
{
    
    float timer = 0.4f;
    bool blast;
    
    Vector3 scaleUp = new Vector3(1, 1, 1);

    
    Vector3 finalScale;
    public MedusaController controller;

    //script for power shield blast away
    //the shield will blow up and push ulysses away when too close

    private void Update()
    {
        if(!blast)
        {
            if (timer <= 0)
            {

                controller.animatorController.animator.enabled = true;
                blast = true;

            }
            else
                timer -= Time.deltaTime;
        }
    }

    

}
