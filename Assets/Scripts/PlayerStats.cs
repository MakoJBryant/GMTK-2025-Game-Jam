using UnityEngine;

public class PlayerStats : MonoBehaviour
{

    public int
        maxHealth = 250, 
        currentHealth, 
        shield,
        maxShield = 100;

    public float power = 5f;
    //public float critRate = 1;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        currentHealth = maxHealth;
        shield = maxShield; // Initialize shield to maximum value
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void TakeDamage(int amount)
    {

        if(shield > 0)
        {
            shield -= amount;
            if(shield < 0)
            {
                shield = 0; // Ensure shield does not go below 0
            }
        }
        else
        {
            currentHealth -= amount;
        }

        if(currentHealth <= 0)
        {
            currentHealth = 0; // Ensure health does not go below 0
            Debug.Log("Player is dead!");
            // Handle player death (e.g., trigger game over, respawn, etc.)
        }
    }


}
