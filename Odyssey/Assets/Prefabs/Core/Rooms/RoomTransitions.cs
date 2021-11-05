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
    public bool merchantRoomUnlocked;
    [SerializeField] Room merchantRoom;
    [SerializeField] FollowCamera followCamera;
    [SerializeField] SmoothFollowCamera smoothFollowCamera;


    private void Start()
    {
        //first room is index 0
        currentRoomIndex = 0;

        SetupRooms();

        //set color to image color
        imageColor = screenBlocker.color;

    }

    void SetupRooms()
    {
        
        //setup rooms
        rooms = this.GetComponentsInChildren<Room>();
        for (int i = 1; i < rooms.Length - 1; i++)
        {
            int randomIndex = Random.Range(1, rooms.Length - 1);
            rooms[i].transform.SetSiblingIndex(randomIndex);
            rooms[i] = null;
        }

        rooms = this.GetComponentsInChildren<Room>();

        //setup next roomPrizes
        for (int i = 1; i < rooms.Length - 1; i++)
        {
            rooms[i].roomIndex = i;
            rooms[i].nextRoomPrize = rooms[i + 1].middlePrize;
            rooms[i].gameObject.SetActive(false);
        }

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
        
        if(merchantRoom.transition)
        {
            merchantRoomUnlocked = false;
            transitionScreenOut = true;
            merchantRoom.transition = false;
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
            if(!merchantRoomUnlocked)
            {
                currentRoomIndex++;
                rooms[currentRoomIndex].gameObject.SetActive(true);
            }
            transitionScreenIn = true;
            transitionScreenOut = false;
        }
    }

    private void ScreenTransitionIn()
    {
        if (!merchantRoomUnlocked)
        {
            player.position = rooms[currentRoomIndex].entry.position;
            player.rotation = rooms[currentRoomIndex].entry.localRotation;
            followCamera.enabled = true;
            smoothFollowCamera.enabled = false;

        }
        
        if(merchantRoomUnlocked)
        {
            followCamera.enabled = true;
            smoothFollowCamera.enabled = false;
            player.position = merchantRoom.entry.position;
            player.rotation = merchantRoom.entry.localRotation;
        }

        imageColor.a -= transitionSpeed * Time.deltaTime;
        screenBlocker.color = imageColor;

        if (screenBlocker.color.a <= 0)
        {
            followCamera.enabled = false;
            smoothFollowCamera.enabled = true;
            transitionScreenIn = false;
            imageColor.a = 0;
        }

        
    }

}
