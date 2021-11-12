using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class R1Transition : MonoBehaviour
{
    [SerializeField] GameObject room0hud;
    [SerializeField] GameObject room1hud;
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
                if(room0hud!=null)
                    room0hud.SetActive(false);
                if (room1hud != null)
                    room1hud.SetActive(true);
                room.transition = true;
            }

        }
        
    }
}
