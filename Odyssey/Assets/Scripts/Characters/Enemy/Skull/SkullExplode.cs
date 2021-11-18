using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkullExplode : MonoBehaviour
{
    public void deathSound()
    {
        transform.parent.GetComponent<CharacterSounds>().PlayDeathSound();
    }
}
