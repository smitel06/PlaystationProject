using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dash : MonoBehaviour
{
    PlayerController controller;
    [SerializeField] ParticleSystem dashFX;
    public float dashTime = 0.2f;
    private float dashDistance = 5f;
    private float currentDashTime = 0f;
    private bool dashing = false;
    public bool lightningQ;
    private Vector3 dashBegin, dashEnd;
    Vector3 input;
    

    //stuff for iso control
    Vector3 forward, right;

    private void Start()
    {
        controller = GetComponent<PlayerController>();
        //set forward vector to camera
        forward = Camera.main.transform.forward;
        forward.y = 0;
        forward = Vector3.Normalize(forward);

        //set right vector
        right = Quaternion.Euler(new Vector3(0, 90, 0)) * forward;
    }
    void Update()
    {
        

        //things for iso movement
        Vector3 rightMovement = right * Input.GetAxisRaw("HorizontalMovement");
        Vector3 upMovement = forward  * Input.GetAxisRaw("VerticalMovement");
        input = Vector3.Normalize(rightMovement + upMovement);

        if (!GetComponent<PlayerController>().dead && !GetComponent<PlayerController>().pausePlayer)
        {
            if (Input.GetButtonDown("Dash"))
            {
                Debug.Log("Dash");
                if (dashing == false)
                {
                    if(GetComponent<playerBuffs>().lightningQuick)
                    {
                        lightningQ = true;
                    }
                    // dash starts
                    dashing = true;
                    currentDashTime = 0;
                    dashBegin = transform.position;
                    dashEnd = transform.position += input * dashDistance;
                    GetComponent<Health>().enabled = false;
                }
            }
        }

        if (dashing)
        {
            dashFX.Play();
            // incrementing time
            currentDashTime += Time.deltaTime;

            // a value between 0 and 1
            float perc = Mathf.Clamp01(currentDashTime / dashTime);

            // updating position
            transform.position = Vector3.Lerp(dashBegin, dashEnd, perc);

            if (currentDashTime >= dashTime)
            {
                // dash finished
                transform.position = dashEnd;
                dashing = false;
                GetComponent<Health>().enabled = true;
            }
        }
        else
        {
            dashFX.Stop();
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(dashing)
        {
            dashing = false;
        }
    }


}
