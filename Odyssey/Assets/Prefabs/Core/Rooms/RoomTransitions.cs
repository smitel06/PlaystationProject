using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RoomTransitions : MonoBehaviour
{
    [SerializeField] Transform player;
    [SerializeField] int currentRoomIndex;
    [SerializeField] Room[] rooms;
    [SerializeField] Image screenBlocker;
    Color imageColor;
    bool transitionScreenOut;
    bool transitionScreenIn;
    public float transitionSpeed;
    

    private void Start()
    {
        //first room is index 0
        currentRoomIndex = 0;

        //setup rooms
        rooms = this.GetComponentsInChildren<Room>();

        //set color to image color
        imageColor = screenBlocker.color;

    }

    private void Update()
    {
        //checks current room 
        //on true transition to next room with index +1
        if (rooms[currentRoomIndex].transition)
        {
            
            transitionScreenOut = true;
            rooms[currentRoomIndex].transition = false;
        }

        Transition();

    }

    private void Transition()
    {
        if (transitionScreenOut)
        {
            ScreenTransitionOut();
        }

        if (transitionScreenIn)
        {
            ScreenTransitionIn();
        }
    }

    private void ScreenTransitionOut()
    {
        
        imageColor.a += transitionSpeed * Time.deltaTime;
        screenBlocker.color = imageColor;

        if(screenBlocker.color.a >= 1)
        {
            currentRoomIndex++;
            transitionScreenIn = true;
            transitionScreenOut = false;
        }
    }

    private void ScreenTransitionIn()
    {
        player.position = rooms[currentRoomIndex].entry.position;
        player.rotation = rooms[currentRoomIndex].entry.localRotation;

        imageColor.a -= transitionSpeed * Time.deltaTime;
        screenBlocker.color = imageColor;

        if (screenBlocker.color.a <= 0)
        {
            transitionScreenIn = false;
            imageColor.a = 0;
            
        }
    }

}
