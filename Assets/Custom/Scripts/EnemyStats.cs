using UnityEngine;

public class EnemyStats : MonoBehaviour
{

    public PlayerStats playerStats;
    private GameData data;

    public float defense = 5f;
    public int damage = 25;
    public int health, maxHealth = 100;

    [SerializeField] private ParticleSystem deathParticle;
    

    Animator animator;
    private void Start()
    {
        animator = GetComponentInChildren<Animator>();
        playerStats = GameManager.instance.player.GetComponent<PlayerStats>();
        data = GameManager.instance.data;
        defense *= data.difficulty;
        damage = Mathf.RoundToInt(damage * data.difficulty);
        maxHealth = Mathf.RoundToInt(maxHealth * data.difficulty);
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
            animator.SetTrigger("Die");
            Instantiate(deathParticle, transform.position, transform.rotation);
            Invoke("DisableEnemy", .10f);
        }
    }

    private void DisableEnemy()
    {
        gameObject.SetActive(false);
    }
}
