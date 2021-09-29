using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIMover : MonoBehaviour
{
    //player
    GameObject target;
    //navigation agent
    NavMeshAgent agent;
    //random offset from target
    Vector3 randOffset;
    public float offsetDistanceMin;
    public float offsetDistanceMax;
    //bool for slot placement
    public bool inSlot;
    //slot target
    public GameObject slot;

    private void Start()
    {
        //easier to type
        target = GameObject.FindGameObjectWithTag("Player");
        agent = GetComponent<NavMeshAgent>();
        //random vector so all enemies aren't crowding the destination
        //use max and min to set radius near player
        randOffset = new Vector3(Random.Range(offsetDistanceMin, offsetDistanceMax), Random.Range(offsetDistanceMin, offsetDistanceMax), Random.Range(offsetDistanceMin, offsetDistanceMax));


    }

    void Update()
    {
        UpdateDestination();
    }

    void UpdateDestination()
    {
        if(!inSlot)
        {
            agent.destination = target.transform.position + randOffset;
        }
        else
        {
            agent.destination = slot.transform.position;
        }
    }
}
