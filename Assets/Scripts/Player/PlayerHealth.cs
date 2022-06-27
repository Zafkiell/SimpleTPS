using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 3;
    [HideInInspector]
    public int currentHealth;
    bool invulnerable = false;
    public HelathBarScript health;
    public AudioSource healthSound;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            TakeDamage(1);
        }
        if(Input.GetKeyDown(KeyCode.E))
        {
            GainHealth(1);
        }
    }
    public void GainHealth(int healthAmmount)
    {
        currentHealth += healthAmmount;
        health.UpdateHealth(currentHealth);
        healthSound.Play();
    }
    public void TakeDamage(int damage)
    {
        if(!invulnerable)
        {
            currentHealth -= 1;
            health.UpdateHealth(currentHealth);

            if(currentHealth <=0)
            {
                Die();
            }

            Invoke("BeVulnerable",2f);
            invulnerable = true;
        }
    }
    void BeVulnerable()
    {
        invulnerable = false;
    }

    void Die() 
    {
        gameObject.SetActive(false);
        //Destroy(gameObject);
        //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
