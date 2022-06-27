using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HelathBarScript : MonoBehaviour
{
    public Image[] hearts;
    int maxHealth = 3;
    int health;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateHealth(int currentHealth)
    {
        health = currentHealth;

        for(int i = 0; i < maxHealth; i++)
        {
            if(health <= i)
            {
                hearts[i].enabled = false;
            }else{
                hearts[i].enabled = true;
            }
        }
    }
}
