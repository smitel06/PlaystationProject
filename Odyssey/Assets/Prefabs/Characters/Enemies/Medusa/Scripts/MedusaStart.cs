using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MedusaStart : MonoBehaviour
{
    [SerializeField] MedusaController controller;
    public bool begin;
    private void Update()
    {
        if(begin)
        {
            controller.animatorController.animator.SetTrigger("start");
        }
    }
}
