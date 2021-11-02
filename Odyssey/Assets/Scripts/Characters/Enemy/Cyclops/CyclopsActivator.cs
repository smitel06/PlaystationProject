using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyclopsActivator : MonoBehaviour
{
    [SerializeField] GameObject target;

    private void OnEnable()
    {
        target = GameObject.Find("Player");
    }
    private void Update()
    {
        if (Vector3.Distance(target.transform.position, transform.position) < 10)
        {
            GetComponent < CyclopsController>().enabled = true;
        }
    }
}
