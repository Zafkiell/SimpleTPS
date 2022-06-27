using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public float fireRate = .5f;
    public GameObject bullet;
    public Transform shootPoint;
    public enum weapon{NORMAL,TANK};
    public weapon wp = weapon.NORMAL;
    public AudioSource bulletSound;

    //tank variables
    Transform target;

    bool startShoot = false;
    bool canShoot = true;
    bool takeAim = false;
    public bool rotateSearch;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("OpenFire",1f);
        target = FindObjectOfType<PlayerMovement>().gameObject.transform;
    }
    void OpenFire()
    {
        startShoot = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(startShoot)
        {
            switch(wp) 
            {
                case(weapon.NORMAL):
                    if(canShoot)
                    {
                        Fire();
                        canShoot = false; 
                    }
                    break;
                    case(weapon.TANK):
                    if(canShoot)
                    {
                        if(GetComponent<EnemyViewAngle>().targetAquired)
                        {
                            Fire();
                            takeAim = true;
                            canShoot = false;
                        }
                        else{
                            takeAim = false;
                        }
                    }
                break;
                default:
                break;
            }
            //Search for player
            if(rotateSearch && !takeAim)RotateSearch();
            //Aim at player if can see him
            if(takeAim)AimAtPlayer();

        } 
    }
    void Fire()
    {
        Instantiate(bullet,shootPoint.position,shootPoint.rotation);
        Invoke("nextShot",fireRate);
        bulletSound.Play();
    }
    void AimAtPlayer()
    {
        Vector3 lookVector = target.transform.position - transform.position;
        lookVector.y = transform.position.y;
        Quaternion rot = Quaternion.LookRotation(lookVector);
        transform.rotation = Quaternion.Slerp(transform.rotation, rot, .1f);
    }
    void RotateSearch()
    {
        transform.Rotate(new Vector3(0,1,0), Space.Self);
    }
    void nextShot()
    {
        canShoot = true;
    }
}
