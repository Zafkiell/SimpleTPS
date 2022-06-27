using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            if(other.GetComponent<PlayerHealth>().currentHealth < 3)
            {
                other.GetComponent<PlayerHealth>().GainHealth(1);
                Destroy(gameObject);
            }
        }
    }
}
