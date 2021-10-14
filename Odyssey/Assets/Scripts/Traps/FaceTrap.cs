using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceTrap : MonoBehaviour
{
    Animator animator;
    float flameDamage = 15f;
    bool off;
    [SerializeField] GameObject ParticleEffect;
    

    void OnEnable()
    {
        animator = GetComponent<Animator>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            if (!off)
            {
                
                animator.enabled = true;
                StartCoroutine(Activate(other.gameObject));
                off = true;
            }
        }
    }

    IEnumerator Activate(GameObject other)
    {
        ParticleEffect.SetActive(true);
        other.GetComponent<Health>().TakeDamage(flameDamage);
        yield return new WaitForSeconds(1.0f);
        animator.enabled = false;
        ParticleEffect.SetActive(false);
    }


}
