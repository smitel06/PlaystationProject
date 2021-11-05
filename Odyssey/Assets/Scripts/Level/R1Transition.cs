using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R1Transition : MonoBehaviour
{
    [SerializeField] Room room;
    float distance;
    [SerializeField] float minDistance;
    [SerializeField] GameObject player;
    private void Update()
    {
        distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance < minDistance)
        {
            if(Input.GetButtonDown("Interact"))
            {
                room.transition = true;
            }

        }
        
    }
}
