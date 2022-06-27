using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBox : MonoBehaviour
{
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<PlayerShoot>().wp = PlayerShoot.weapon.MACHINE;
            other.GetComponent<PlayerShoot>().machineSound.Play();
            Destroy(gameObject);
        }
    }
}
