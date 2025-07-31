using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    Player player;

    private void Start()
    {
        player = Game_Manager.instance.player;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        switch (collision.gameObject.tag)
        {
            case "Enemy":
                EnemyStats enemy = collision.gameObject.GetComponent<EnemyStats>();
                player.stats.TakeDamage(enemy.damage);
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Shield":
                player.stats.RegenShield();
                break;
        }
    }
}
