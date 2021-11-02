using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameAssets : MonoBehaviour
{
    private static GameAssets _i;

    public static GameAssets i
    {
        get
        {
            if(_i == null)
            {
                _i = (Instantiate(Resources.Load("GameAssets")) as GameObject).GetComponent<GameAssets>();
            }
            return _i;
        }
    }

    //asset for damage popup
    public Transform damagePopUpPrefab;

    //enemy assets to use
    public GameObject enemySkull;
    public GameObject enemyCyclops;
    public GameObject enemySorceror;

    //coin prefab drop
    public GameObject coinDrop;
}
