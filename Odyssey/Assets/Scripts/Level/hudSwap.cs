using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hudSwap : MonoBehaviour
{
    [SerializeField] GameObject room0hud;
    [SerializeField] GameObject room1hud;
    float distance;
    [SerializeField] float minDistance;
    [SerializeField] GameObject player;
    private void Update()
    {


        distance = Vector3.Distance(player.transform.position, transform.position);

        if (distance < minDistance)
        {
            if (Input.GetButtonDown("Interact"))
            {
                StartCoroutine(swapHUD());
            }

        }
        

        
    }

    IEnumerator swapHUD()
    {
        yield return new WaitForSeconds(2f);
        room0hud.SetActive(false);
        room1hud.SetActive(true);
    }
}
