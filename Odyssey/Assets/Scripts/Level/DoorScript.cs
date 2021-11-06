using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorScript : MonoBehaviour
{
    [SerializeField] GameObject player;
    [SerializeField] GameObject doorPrize;
    [SerializeField] RoomExit exit;
    public bool open;
    [SerializeField] float doorSpeed;

    private void Start()
    {
        player = GameObject.Find("Player");
    }
    private void Update()
    {
        if(doorPrize == null && transform.localPosition.y < 0.08)
        {
            player.GetComponent<PlayerController>().pausePlayer = true;
            transform.Translate(Vector3.up * Time.deltaTime * doorSpeed, Space.World);
        }
        else if(transform.localPosition.y >= 0.08 && !open)
        {
            open = true;
        }

        if(open)
        {
            movePlayer();
        }
        
    }

    void movePlayer()
    {
        player.GetComponent<PlayerController>().pausePlayer = true;
        Rigidbody rb = player.GetComponent<Rigidbody>();

        //player to look at exit
        Vector3 direction = (exit.transform.position - player.transform.position).normalized;
        player.transform.LookAt(exit.gameObject.transform);
        rb.velocity = direction * 5.737815f;
        player.GetComponent<Animator>().SetFloat("Blend", 5.737815f);

    }

}
