using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{
    Animator animator;
    float spikeDamage = 15f;
    bool cooldown;

    void OnEnable ()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!cooldown)
            {
                animator.enabled = true;
                StartCoroutine(Activate(other.gameObject));
                cooldown = true;
            }
        }
    }

    IEnumerator Activate(GameObject other)
    {
        animator.SetBool("active", true);
        other.GetComponent<Health>().TakeDamage(spikeDamage);
        yield return new WaitForSeconds(1.0f);
        animator.SetBool("active", false);
        yield return new WaitForSeconds(2.0f);
        cooldown = false;
    }    

    void SpikeOut()
    {
        AudioManager.instance.Play("U_TS_Spikes");
    }

    void SpikePlate()
    {
        AudioManager.instance.Play("U_TS_Trigger4");
    }

}
