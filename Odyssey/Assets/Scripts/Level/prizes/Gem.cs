using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField] ParticleSystem effect;
    [SerializeField] float rotationSpeed;
    [SerializeField] GameObject parent;
    [SerializeField] GameObject achievement;
    bool shrink;
    Prize prize;

    private void OnEnable()
    {
        prize = parent.GetComponent<Prize>();
        achievement = prize.achievementReferences.DivineJewels;
    }


    void Update()
    {
        // Rotate the object around its local y axis so it appears to be spinning
        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);

        //when collecting prize shrink
        if (shrink && transform.localScale.x >= 0.01f)
        {
            if(prize.lotus != null)
                prize.lotus.transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);

            transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
        }
    }

    public void Collect()
    {
        effect.Play();
        shrink = true;
        achievement.SetActive(true);

        //spawn door prizes
        if (prize.middlePrize)
        {
            prize.player.gameObject.GetComponent<PlayerCurrencies>().gems++;

            if (prize.doorPrize1 != null)
            {
                prize.doorPrize1.nextRoomPrize = prize.nextRoomPrize;
                prize.doorPrize1.SpawnPrize();
            }

            if (prize.doorPrize2 != null)
            {
                prize.doorPrize2.nextRoomPrize = prize.nextRoomPrize;
                prize.doorPrize2.SpawnPrize();
            }

            if (prize.doorPrize3 != null)
            {
                prize.doorPrize3.nextRoomPrize = prize.nextRoomPrize;
                prize.doorPrize3.SpawnPrize();
            }
        }
        else
        {
            prize.nextRoomPrize.prizeType = 0;

        }

        Destroy(parent, 1.5f);
    }
}
