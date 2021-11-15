using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldBlast : MonoBehaviour
{
    [SerializeField] ParticleSystem powerDraw;
    float powerDrawTimer = 1f;
    bool blast;
    [SerializeField] float blastEffectSpeed;
    Vector3 scaleUp = new Vector3(1, 1, 1);

    float currentScaleTime;
    float scaleTime = 1f;
    Vector3 finalScale;
    public MedusaController controller;

    //script for power shield blast away
    //the shield will blow up and push ulysses away when too close

    private void Update()
    {
        if(!blast)
        {
            if (powerDrawTimer <= 0)
            {
                finalScale = transform.localScale * blastEffectSpeed;
                powerDraw.Stop();
                controller.animatorController.animator.enabled = true;
                blast = true;

            }
            else
                powerDrawTimer -= Time.deltaTime;
        }

        //now for the blasting effect
        if (blast)
        {

            currentScaleTime += Time.deltaTime;

            // a value between 0 and 1
            float perc = Mathf.Clamp01(currentScaleTime / scaleTime);

            // updating scale
            transform.localScale = Vector3.Lerp(transform.localScale, finalScale, perc);

            if (finalScale.x <= transform.localScale.x)
                Destroy(gameObject);
           
        }
    }

}
