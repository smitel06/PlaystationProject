using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWeapon : MonoBehaviour
{
    [SerializeField] int damage;
    [SerializeField] public GameObject player;
    [SerializeField] playerBuffs playerBuffs;

    int bloodCounter;

    private void Start()
    {
        playerBuffs = player.GetComponent<playerBuffs>();
        
    }

    private void OnTriggerEnter(Collider other)
    {
        damage = player.GetComponent<Damage>().currentDamage;
        if (other.gameObject.tag == "Enemy")
        {
            Debug.Log("got after damage increase");
            float mMIncrease = player.GetComponent<Damage>().massiveMomentumIncrease;
            damage += (int)mMIncrease;
            

            if (!playerBuffs.bloodLust)
            {
                
            }
            else
            {
                if(bloodCounter > 0)
                {
                    //add some sort of red glow to sword if blood lust is working????
                    damage += player.GetComponent<Damage>().currentDamage / 4;
                    bloodCounter--;
                }
                else
                {
                    bloodCounter++;
                    damage = player.GetComponent<Damage>().currentDamage;
                } 
            }
            if(playerBuffs.assassinsDagger)
            {
                int randomNum = Random.Range(0, 101);
                if(randomNum <= 25)
                {
                    float percentageOfDamage = damage * 0.5f;
                    damage = damage + (int)percentageOfDamage;
                }
            }

            other.GetComponent<Health>().TakeDamage(damage);
            GetComponent<Collider>().enabled = false;
            

        }
    }

    
}
