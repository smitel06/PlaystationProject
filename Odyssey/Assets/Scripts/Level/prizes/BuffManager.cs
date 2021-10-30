using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffManager : MonoBehaviour
{
    [SerializeField] List <GameObject> buffs = new List<GameObject>();
    int selectedBuff;

    //buffs
    [SerializeField] GameObject buff1;
    [SerializeField] GameObject buff2;
    [SerializeField] GameObject buff3;
    [SerializeField] GameObject buff4;
    [SerializeField] GameObject buff5;
    [SerializeField] GameObject buff6;
    [SerializeField] GameObject buff7;
    [SerializeField] GameObject buff8;
    [SerializeField] GameObject buff9;
    [SerializeField] GameObject buff10;
    private void OnEnable()
    {
        AddBuffsToArray();
        selectedBuff = Random.Range(0, 10);
        buffs[selectedBuff].gameObject.SetActive(true);
    }

    void AddBuffsToArray()
    {
        buffs.Add(buff1);
        buffs.Add(buff2);
        buffs.Add(buff3);
        buffs.Add(buff4);
        buffs.Add(buff5);
        buffs.Add(buff6);
        buffs.Add(buff7);
        buffs.Add(buff8);
        buffs.Add(buff9);
        buffs.Add(buff10);
    }

}
