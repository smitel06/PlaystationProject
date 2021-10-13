using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboarding : MonoBehaviour
{
    [SerializeField]GameObject cam;
    
    void OnEnable()
    {
        cam = GameObject.FindGameObjectWithTag("MainCamera");
    }
    void Update()
    {
        transform.LookAt(cam.transform);
    }
}
