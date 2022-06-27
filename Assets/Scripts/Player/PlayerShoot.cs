using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public float fireRate = .5f;
    public GameObject bullet;
    public AudioSource shootSound,machineSound,machineShot;
    public Transform shootPoint;
    public enum weapon{NORMAL,MACHINE};
    public weapon wp = weapon.NORMAL;
    string shootAxis;

    int ammo = 400;
    // Start is called before the first frame update
    void Start()
    {
        if(gameObject.name == "Player1")shootAxis = "Fire1";
        if(gameObject.name == "Player2")shootAxis = "Fire2";
    }

    // Update is called once per frame
    void Update()
    {
        switch(wp) 
        {
            case(weapon.NORMAL):
                if(Input.GetButtonDown(shootAxis) && Time.time > .5f)
                {
                    Fire(); 
                    shootSound.Play();
                }
            break;
            case(weapon.MACHINE):
                if(Input.GetButton(shootAxis) && Time.time > fireRate)
                {
                    if(ammo > 0)
                    {
                        Fire();
                        ammo -= 1; 
                        if(!machineShot.isPlaying)machineShot.Play();
                    }else{
                        wp = weapon.NORMAL;
                        ammo = 400;
                    }
                }
                if(Input.GetButtonUp(shootAxis))
                {
                    machineShot.Stop();
                }
            break;
            default:
            break;
        }
        
    }
    void Fire()
    {
        GameObject bullletInstance;
        bullletInstance = Instantiate(bullet,shootPoint.position,shootPoint.rotation) as GameObject;
        bullletInstance.GetComponentInChildren<BulletScript>().playerShot = gameObject.name;
    }
}
