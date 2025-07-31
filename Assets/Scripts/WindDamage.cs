using UnityEngine;

public class WindDamage : MonoBehaviour
{

    public PlayerStats playerStats; // Reference to the PlayerStats script
    public int windDamage = 10; // Amount of damage dealt by the wind

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            EnemyStats enemy = other.GetComponent<EnemyStats>();
            float damageOutput = (playerStats.power / enemy.defense) * windDamage;
            Debug.Log("Wind damage triggered on enemy! " + damageOutput);
            enemy.TakeDamage((int)damageOutput);
        }
    }
}
