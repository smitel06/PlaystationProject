using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomExit : MonoBehaviour
{
    [SerializeField] GameObject room;

    private void OnCollisionEnter(Collision other)
    {
        //check for player
        if (other.gameObject.tag == ("Player"))
        {
            //allow transition
            room.GetComponent<Room>().transition = true;
        }
    }
}
