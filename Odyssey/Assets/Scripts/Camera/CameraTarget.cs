using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTarget : MonoBehaviour
{
    [SerializeField] SmoothFollowCamera smoothFollowCamera;
    [SerializeField] Transform target;
    [SerializeField] float minDistanceTillSwap;
    bool enableScript;
    private void Update()
    {
        if (enableScript)
        { 
            if (Vector3.Distance(target.transform.position, transform.position) < minDistanceTillSwap)
            {
                smoothFollowCamera.target = transform;
            }
            else
            {
                smoothFollowCamera.target = target;
            }
        }

        if (Vector3.Distance(target.transform.position, transform.position) < minDistanceTillSwap && !enableScript)
        {
            enableScript = true;
        }
    }
} 
