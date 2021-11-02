using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VaseObject : MonoBehaviour
{
    [SerializeField] Animator anim;
    
    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "PlayerWeapon")
        {
            anim.enabled = true;
        }
    }
}
