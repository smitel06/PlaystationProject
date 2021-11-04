using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionActivateGameObject : MonoBehaviour
{
    [SerializeField] GameObject objectToActivate;

    private void OnTriggerEnter(Collider collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            objectToActivate.SetActive(true);
        }    
    }
}
