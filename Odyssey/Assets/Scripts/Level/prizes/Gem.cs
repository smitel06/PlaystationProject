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
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            
            effect.Play();
            shrink = true;
            //achievement.SetActive(true);
            //achievement.GetComponent<Achievement>().setText("Acquired: Gem");
            
            //spawn door prizes
            if(prize.middlePrize)
            {
                collision.gameObject.GetComponent<PlayerCurrencies>().gems++;
                if (prize.doorPrize1 != null)
                {
                    prize.doorPrize1.SpawnPrize();
                }

                if (prize.doorPrize2 != null)
                {
                    prize.doorPrize1.SpawnPrize();
                }
            }
            else
            {
                prize.nextRoomPrize.prizeType = 0;
                
            }
            
            Destroy(parent, 1.5f);
        }
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
