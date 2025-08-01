using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    Player player;
    Room_Manager room;

    private void Start()
    {
        player = Game_Manager.instance.player;
        room = Game_Manager.instance.room;
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
            case "Exit":
                int enemiesLeft = 0;
                foreach (Transform enemy in room.enemyContainer)
                {
                    if (enemy.gameObject.activeInHierarchy)
                        enemiesLeft++;
                }
                Debug.Log(enemiesLeft);
                if (enemiesLeft <= 0)
                    Game_Manager.instance.HandleWin();
                break;
        }
    }
}
