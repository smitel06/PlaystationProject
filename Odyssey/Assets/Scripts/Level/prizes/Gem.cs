using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gem : MonoBehaviour
{
    [SerializeField] ParticleSystem effect;
    [SerializeField] float rotationSpeed;
    [SerializeField] GameObject parent;
    [SerializeField] GameObject achievement;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerCurrencies>().gems++;
            effect.Play();

            achievement.SetActive(true);
            achievement.GetComponent<Achievement>().setText("Acquired: Gem");

            Destroy(parent, 1.5f);
        }
    }

    void Update()
    {
        // Rotate the object around its local y axis so it appears to be spinning
        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed);
    }
}
