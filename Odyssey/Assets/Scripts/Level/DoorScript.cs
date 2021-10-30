using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] GameObject doorPrize;
    bool open;
    [SerializeField] float doorSpeed;
    private void Update()
    {
        if(doorPrize == null && transform.localPosition.y < 0.08)
        {
            transform.Translate(Vector3.up * Time.deltaTime * doorSpeed, Space.World);
        }
        else if(transform.localPosition.y >= 0.08 && !open)
        {
            open = true;
        }
        
    }

}
