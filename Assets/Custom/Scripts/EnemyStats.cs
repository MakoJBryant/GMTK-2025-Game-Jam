using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public PlayerStats playerStats;

    public float defense = 5f;
    public int damage = 25;
    public int health, maxHealth = 100;

    private void Start()
    {
        playerStats = GameManager.instance.player.GetComponent<PlayerStats>();
        health = maxHealth;
    }

    public void TakeDamage(int amount)
    {
        health -= amount;
        if (health <= 0)
        {
            health = 0;
            Debug.Log("Enemy is dead!");

            // GameManager.instance.audioManager.Play("Test Death"); // Play death sound

            gameObject.SetActive(false);
        }
    }
}
