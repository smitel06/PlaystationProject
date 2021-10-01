using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.ParticleSystemJobs;
using System;

public class ParticleManager : MonoBehaviour
{
    public Particle[] particleEffects;
    public static ParticleManager instance;



    //Use this for initialization
    void Awake()
    {

        if (instance == null)
            instance = this;
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);


        foreach (Particle p in particleEffects)
        {
            //set the system
            ParticleSystem.MainModule main = p.prefab.GetComponent<ParticleSystem>().main;
            //set the variables
            p.prefab.transform.position = p.location.position;
            //set variables
            

        }
    }

    

    public void Play(string name)
    {
        Particle p = Array.Find(particleEffects, particle => particle.name == name);
        if (p == null)
        {
            Debug.LogWarning("Particle: " + name + " not found!");
            return;
        }
        else
        {
            Instantiate(p.prefab, p.location);
        }
        
    }


}

