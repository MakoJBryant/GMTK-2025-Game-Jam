using UnityEngine;

public class PlayerCollisions : MonoBehaviour
{
    private Player player;
    private RoomManager room;

    private bool IsRoomEmpty()
    {
        int enemiesLeft = 0;
        foreach (Transform enemy in room.EnemyContainer)
        {
            if (enemy.gameObject.activeInHierarchy)
                enemiesLeft++;
        }

        if (enemiesLeft <= 0)
        {
            return true;
        }
        else
        {
            Debug.Log("Cannot pass, " + enemiesLeft + " enemies left.");
            return false;
        }
    }

    private void Start()
    {
        player = GameManager.instance.player;
        room = GameManager.instance.room;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Debug.Log("Collision");
        switch (collision.gameObject.tag)
        {
            case "Enemy":
                EnemyStats enemy = collision.gameObject.GetComponent<EnemyStats>();
                player.stats.TakeDamage(enemy.damage);
                player.visualControl.ShowColorFeedback(Color.red, 15, .1f);
                break;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Shield":
                ShieldRegenerator shield = collision.GetComponent<ShieldRegenerator>();
                if (!shield.ShouldIncreaseOpacity)
                {
                    shield.ShieldCooldownBehavior();
                    player.visualControl.ShowColorFeedback(Color.blue, 10, .25f);
                    player.stats.RegenShield();
                }
                break;

            case "Exit":
                if (IsRoomEmpty())
                    GameManager.instance.HandleWin();
                break;
        }
    }
}
