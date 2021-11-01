using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hudSwap : MonoBehaviour
{
    [SerializeField] GameObject room0hud;
    [SerializeField] GameObject room1hud;
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {

            StartCoroutine(swapHUD());

        }
    }

    IEnumerator swapHUD()
    {
        yield return new WaitForSeconds(2f);
        room0hud.SetActive(false);
        room1hud.SetActive(true);
    }
}
