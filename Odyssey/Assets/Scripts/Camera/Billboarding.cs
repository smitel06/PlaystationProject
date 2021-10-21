using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboarding : MonoBehaviour
{
    private void Update()
    {
        Quaternion lookRotation = Camera.main.transform.rotation;
        transform.rotation = lookRotation;
    }
}
