using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heart : MonoBehaviour
{
    [SerializeField] ParticleSystem effect;
    [SerializeField] float rotationSpeed;
    [SerializeField] GameObject parent;
    [SerializeField] int healthIncrease;
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
            //achievement.GetComponent<Achievement>().setText("Acquired: Heart");

            //spawn door prizes
            if (prize.middlePrize)
            {
                collision.gameObject.GetComponent<Health>().changeMaxValue(healthIncrease);
                prize.doorPrize1.SpawnPrize();
                if (prize.doorPrize2 != null)
                {
                    prize.doorPrize1.SpawnPrize();
                }
            }
            else
            {
                prize.nextRoomPrize.prizeType = 2;
            }

            Destroy(gameObject, 1.5f);
        }
    }

    void Update()
    {
        // Rotate the object around its local y axis so it appears to be spinning
        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);

        //when collecting prize shrink
        if(shrink && transform.localScale.x >= 0.3f)
{
            transform.localScale -= new Vector3(0.1f, 0.1f, 0.1f);
        }
    }
}
