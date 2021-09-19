using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class weaponScript : MonoBehaviour
{
    //special fx variables
    public GameObject bloodsplat;
    public Transform hitPoint;
    //------------------------
    public bool attackOn;

    private void OnCollisionEnter(Collision collision)
    {

        if (collision.gameObject.tag == "Enemy" && attackOn)
        {
            Instantiate(bloodsplat, hitPoint.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("Not enemy");
        }
    }
}
