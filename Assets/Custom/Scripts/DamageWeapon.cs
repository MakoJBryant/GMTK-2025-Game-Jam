using UnityEngine;

public class DamageWeapon : MonoBehaviour
{

    PlayerStats playerStats; // Reference to the PlayerStats script
    public int damage = 10; // Amount of damage dealt by the wind

    void Start()
    {
        playerStats = Game_Manager.instance.player.stats; // Get the PlayerStats instance from the Game_Manager
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            EnemyStats enemy = other.GetComponent<EnemyStats>();
            float damageOutput = (playerStats.power / enemy.defense) * damage;
            Debug.Log("Wind damage triggered on enemy! " + damageOutput);
            enemy.TakeDamage((int)damageOutput);
        }
    }
}
