using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceTrap : MonoBehaviour
{
    Animator animator;
    float flameDamage = 5f;
    bool off;
    [SerializeField] GameObject ParticleEffect;
    [SerializeField]float timer;
    float startTimer;
    [SerializeField] string soundEffect;

    private void Start()
    {
        startTimer = timer;
    }
    private void Update()
    {
        if(off)
        {
            timer -= Time.deltaTime;
        }

        if(timer <= 0)
        {
            off = false;
            timer = startTimer;

        }
    }

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
        AudioManager.instance.Play(soundEffect);
        ParticleEffect.SetActive(true);
        AudioManager.instance.Play("U_TF_Attacks3");
        other.GetComponent<Health>().TakeDamage(flameDamage);
        yield return new WaitForSeconds(1.0f);
        animator.enabled = false;
        ParticleEffect.SetActive(false);
    }


}
