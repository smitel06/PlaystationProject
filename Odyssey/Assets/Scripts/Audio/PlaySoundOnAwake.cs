using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundOnAwake : MonoBehaviour
{
    GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.Find("Player");
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position, player.transform.position) <= 15)
        {
            GetComponent<AudioSource>().enabled = true;
        }
        else
            GetComponent<AudioSource>().enabled = false;

    }
}
