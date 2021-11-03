using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpScript : MonoBehaviour
{
    float distance;
    [SerializeField] float minDistance;
    [SerializeField]GameObject player;
    [SerializeField] GameObject popUp;
    

    private void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance < minDistance)
        {
            popUp.SetActive(true);

        }
        else
        {
            popUp.SetActive(false);
        }
    }
}
