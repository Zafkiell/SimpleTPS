using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public int maxHealth;
    int health;
    bool invulnerable = false;
    public int pointsValue;
    public DissolveEffectScript[] gfx;
    // Start is called before the first frame update
    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void TakeDamage(int damage,string culprit)
    {
        if(!invulnerable)
        {
            health -= damage;
            invulnerable = true;
            //Invoke("BeVulnerable",.1f);
            BeVulnerable();
        }

        if(health <= 0)
        {
            if(culprit == "Player1")GameObject.FindObjectOfType<PointsScript>().pontos1 += pointsValue;
            if(culprit == "Player2")GameObject.FindObjectOfType<PointsScript>().pontos2 += pointsValue;
            GameObject.FindObjectOfType<PointsScript>().AddScore();
            if(GetComponent<EnemyShoot>() != null)GetComponent<EnemyShoot>().enabled = false;
            GetComponent<Collider>().enabled = false;
            if(GetComponent<EnemyChase>() != null)GetComponent<EnemyChase>().enabled = false;
            Snap();            
        }
    }
    void Snap()
    {
        for(int i = 0; i < gfx.Length; i++)
        {
            gfx[i].startDissolve = true;
        }
        Invoke("Death",1f);
    }
    void Death()
    {
        Destroy(gameObject);
    }
    void BeVulnerable()
    {
        invulnerable = false;
    }
}
