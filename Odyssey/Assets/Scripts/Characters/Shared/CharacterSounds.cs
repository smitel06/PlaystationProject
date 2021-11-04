using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSounds : MonoBehaviour
{
    [SerializeField] string attackSound = "//Insert name of attack sound here";
    [SerializeField] string impactSound = "//Insert name of impact sound here";
    [SerializeField] string deathSound  = "//Insert name of death sound here";

    public void PlayAttackSound()
    {
        AudioManager.instance.Play(attackSound);
    }

    public void PlayImpactSound()
    {
        AudioManager.instance.Play(impactSound);
    }

    public void PlayDeathSound()
    {
        AudioManager.instance.Play(deathSound);
    }
}
