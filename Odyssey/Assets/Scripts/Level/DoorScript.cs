using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject doorPrize;
    [SerializeField] GameObject exit;
    [SerializeField] Room room;
    public bool open;
    bool move;
    [SerializeField] float doorSpeed;
    bool openingSound;
    [SerializeField] string gateOpenSound;
    

    
    private void Update()
    {
        if(doorPrize == null && transform.localPosition.y < 0.08)
        {
            if (!openingSound)
            {
                AudioManager.instance.Play(gateOpenSound);
                openingSound = true;
            }

            player.GetComponent<PlayerController>().pausePlayer = true;
            transform.Translate(Vector3.up * Time.deltaTime * doorSpeed, Space.World);
        }
        else if(transform.localPosition.y >= 0.08 && !open)
        {
            open = true;
        }

        if(open && !move)
        {
            StartCoroutine(transitionRooms());
            move = true;
        }
        
    }

    IEnumerator transitionRooms()
    {
        movePlayer();
        yield return new WaitForSeconds(1);
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<Animator>().SetFloat("Blend", 0);
        room.transition = true;

    }

    void movePlayer()
    {
        player.GetComponent<PlayerController>().pausePlayer = true;
        Rigidbody rb = player.GetComponent<Rigidbody>();

        //player to look at exit
        Vector3 direction = (exit.transform.position - player.transform.position).normalized;
        player.transform.LookAt(exit.gameObject.transform);
        rb.velocity = player.transform.forward * 5.737815f;
        player.GetComponent<Animator>().SetFloat("Blend", 5.737815f);

    }

}
