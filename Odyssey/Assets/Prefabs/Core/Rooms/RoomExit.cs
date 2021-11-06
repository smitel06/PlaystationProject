using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoomExit : MonoBehaviour
{
    [SerializeField] GameObject room;
    [SerializeField] DoorScript door;
    private void OnCollisionEnter(Collision other)
    {
        //check for player
        if (other.gameObject.tag == ("Player"))
        {
            
            
            other.gameObject.GetComponent<Rigidbody>().velocity = Vector3.zero;
            Destroy(door.gameObject);
            other.gameObject.GetComponent<Animator>().SetFloat("Blend", 0);
            
            //allow transition
            room.GetComponent<Room>().transition = true;
        }
    }
}
