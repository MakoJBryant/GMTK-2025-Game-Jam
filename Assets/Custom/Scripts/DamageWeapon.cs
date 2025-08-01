using UnityEngine;

public class DamageWeapon : MonoBehaviour
{
    private PlayerStats playerStats;
    [SerializeField] private int damage = 10;

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
        }
    }
}
