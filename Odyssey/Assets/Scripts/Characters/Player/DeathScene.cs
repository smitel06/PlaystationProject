using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathScene : MonoBehaviour
{
    [SerializeField] GameObject background;
    [SerializeField] GameObject bloodOverlay;
    [SerializeField] GameObject banner;
    private void OnEnable()
    {
        background.SetActive(true);
        bloodOverlay.SetActive(true);
        banner.SetActive(true);
        StartCoroutine(deathSequence());
    }
    IEnumerator deathSequence()
    {
        yield return new WaitForSeconds(5);
        //restart game
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}

