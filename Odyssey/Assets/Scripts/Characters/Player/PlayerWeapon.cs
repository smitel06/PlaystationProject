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
        damage = player.GetComponent<Damage>().currentDamage;
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if (other.gameObject.tag == "Enemy")
        {
            if (playerBuffs.massiveMomentum)
            {
                Debug.Log("got after damage increase");
                float mMIncrease = player.GetComponent<Damage>().massiveMomentumIncrease;
                damage += (int)mMIncrease;
            }

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

            other.GetComponent<Health>().TakeDamage(damage);
            GetComponent<Collider>().enabled = false;
            

        }
    }

    
}
