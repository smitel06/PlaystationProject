using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCamera : MonoBehaviour
{
    //A camera setup to follow the player

    public Transform target;

    void Update()
    {
        //set position of THIS object to targets position
        transform.position = target.transform.position;
    }
}
