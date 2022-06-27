using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemyScript : MonoBehaviour
{
    Rigidbody rb;
    public float speed = 30f;
    public int damage = 1;
    public ParticleSystem particle;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * speed;
        Destroy(gameObject,.5f);
    }
    private void OnTriggerEnter(Collider other) 
    {
        PlayerHealth player = other.GetComponent<PlayerHealth>();
        if(player != null)
        {
            player.TakeDamage(damage);
        }
        ParticleSystem explosion = Instantiate(particle,transform.position,transform.rotation);
        explosion.Play();
        Destroy(gameObject);
    }
}
