using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Particle
{
    //names and stuff
    public string name;
    public GameObject prefab;
    public ParticleSystem particleController;
    public Transform location;
    


    //options
    
    public float duration;
    public bool loop;
    public float maxParticles;
    

}
