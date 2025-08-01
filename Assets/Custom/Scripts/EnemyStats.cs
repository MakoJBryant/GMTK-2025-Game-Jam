using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    public PlayerStats playerStats;
    public int damage = 25;
    public int health, maxHealth = 100;
    public float defense = 5f;

    void Start()
    {
        health = maxHealth; // Initialize health to maximum value
        playerStats = Game_Manager.instance.player.GetComponent<PlayerStats>();
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if(health <= 0)
        {
            health = 0; // Ensure health does not go below 0
            Debug.Log("Enemy is dead!");

            // Use the recommended method to find the AudioManager instance
            Game_Manager.instance.audioManager.Play("Test Death"); // Play death sound

            // Handle enemy death (e.g., destroy object, play animation, etc.)
            gameObject.SetActive(false);
        }
    }
}
