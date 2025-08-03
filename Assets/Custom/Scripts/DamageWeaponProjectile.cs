using UnityEngine;

public class DamageWeaponProjectile : MonoBehaviour
{
    private PlayerStats playerStats;
    [SerializeField] private int damage = 10;
    [SerializeField] private int health = 3;
    [SerializeField] ParticleSystem explode;
    private void Start()
    {
        playerStats = GameManager.instance.player.stats;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            EnemyStats enemy = other.GetComponent<EnemyStats>();
            float damageOutput = (playerStats.Power / enemy.defense) * damage;
            enemy.TakeDamage((int)damageOutput);
            Debug.Log("Wind damage triggered on enemy! " + damageOutput);

            health--;
            if (health <= 0)
            {
                Destroy(gameObject);
                Instantiate(explode, transform.position, transform.rotation);
            }
        }
    }
}
