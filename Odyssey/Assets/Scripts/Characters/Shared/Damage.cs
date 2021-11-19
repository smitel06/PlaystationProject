using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] int baseDamage;
    public int currentDamage;
    int currentDamageHolder;
    public float massiveMomentumIncrease;

    private void OnEnable()
    {
        currentDamage = baseDamage;
    }

    private void Update()
    {
        if(GetComponent<playerBuffs>().massiveMomentum && massiveMomentumIncrease <= 25)
        {
            massiveMomentumIncrease += Time.deltaTime;
            
        }
        else if(!GetComponent<playerBuffs>().massiveMomentum)
        {
            currentDamageHolder = currentDamage;
        }
    }

    public void ResetDamage()
    {
        currentDamage = currentDamageHolder;
    }
}
