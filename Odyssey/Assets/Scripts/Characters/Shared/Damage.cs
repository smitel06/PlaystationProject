using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Damage : MonoBehaviour
{
    [SerializeField] float baseDamage;
    public float currentDamage;

    private void OnEnable()
    {
        currentDamage = baseDamage;
    }
}
