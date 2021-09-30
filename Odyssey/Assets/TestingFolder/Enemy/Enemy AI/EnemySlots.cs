using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//use this class on the player it will manage the attack slot the enemy uses
public class EnemySlots : MonoBehaviour
{
	//variables for handling slots
	private List<GameObject> slots;
	//how many slots will there be
	public int count = 6;
	//how far from the player will the enemies be
	public float distance = 5f;

	void Start()
	{
		//fill up the slots list with unused slots
		slots = new List<GameObject>();
		for (int index = 0; index < count; ++index)
		{
			slots.Add(null);
		}
	}

	//get slots positions
	public Vector3 GetSlotPosition(int index)
	{
		float degreesPerIndex = 360f / count;
		var pos = transform.position;
		var offset = new Vector3(0f, 0f, distance);
		return pos + (Quaternion.Euler(new Vector3(0f, degreesPerIndex * index, 0f)) * offset);
	}

	//reserve slot for an attacker
	public int Reserve(GameObject attacker)
	{
		var bestPosition = transform.position;
		var offset = (attacker.transform.position - bestPosition).normalized * distance;
		bestPosition += offset;
		int bestSlot = -1;
		float bestDist = 99999f;
		for (int index = 0; index < slots.Count; ++index)
		{
			if (slots[index] != null)
				continue;
			var dist = (GetSlotPosition(index) - bestPosition).sqrMagnitude;
			if (dist < bestDist)
			{
				bestSlot = index;
				bestDist = dist;
			}
		}
		if (bestSlot != -1)
			slots[bestSlot] = attacker;
		return bestSlot;
	}

	public void Release(int slot)
    {
		slots[slot] = null;
    }

    //show in scene where the slots will be
    private void OnDrawGizmosSelected()
    {
		{
			for (int index = 0; index < count; ++index)
			{
				if (slots == null || slots.Count <= index || slots[index] == null)
					Gizmos.color = Color.black;
				else
					Gizmos.color = Color.red;
				Gizmos.DrawWireSphere(GetSlotPosition(index), 0.5f);
			}
		}
	}

}
