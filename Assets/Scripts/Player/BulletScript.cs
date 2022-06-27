using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 30f;
    public int damage = 1;
    public ParticleSystem particle;
    [HideInInspector]
    public string playerShot;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        //GetComponentInParent<DestroyTimerScript>().SelfDestruct();
        Destroy(gameObject,.5f);
    }
    private void OnTriggerEnter(Collider other) 
    {
        EnemyScript enemy = other.GetComponent<EnemyScript>();
        if(enemy != null)
        {
            enemy.TakeDamage(damage, playerShot);
        }
        ParticleSystem explosion = Instantiate(particle,transform.position,transform.rotation);
        explosion.Play();
        //GetComponentInParent<DestroyTimerScript>().SelfDestruct();
        Destroy(gameObject);
    }
}
