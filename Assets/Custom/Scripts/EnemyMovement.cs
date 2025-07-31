using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 3f;

    private void Update()
    {
        if (Vector2.Distance(transform.position, Game_Manager.instance.player.transform.position) < .25f)
            return;

        Vector3 direction = (Game_Manager.instance.player.transform.position - transform.position).normalized;
        transform.position += direction * speed * Time.deltaTime;
    }
}
