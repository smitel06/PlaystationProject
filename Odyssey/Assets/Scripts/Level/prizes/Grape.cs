using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grape : MonoBehaviour
{
    [SerializeField] ParticleSystem effect;
    [SerializeField] float rotationSpeed;
    [SerializeField] GameObject parent;
    [SerializeField] GameObject achievement;
    [SerializeField] RoomTransitions roomTransitions;
    bool shrink;
    Prize prize;

    private void OnEnable()
    {
        prize = parent.GetComponent<Prize>();
        achievement = prize.achievementReferences.ForbiddenFruit;
        roomTransitions = prize.roomTransitions;
    }
    private void Collect()
    {
        roomTransitions.merchantRoomUnlocked = true;
        effect.Play();
        shrink = true;
        achievement.SetActive(true);
        prize.nextRoomPrize.prizeType = Random.Range(0,4);
        Destroy(parent, 1.5f);
        
    }

    void Update()
    {
        // Rotate the object around its local y axis so it appears to be spinning
        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);

        //when collecting prize shrink
        if (shrink && transform.localScale.x >= 0.3f)
        {
            transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
        }
    }
}
