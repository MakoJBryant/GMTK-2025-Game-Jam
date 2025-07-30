using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject player; // Reference to the player GameObject
    public float speed = 3f;
    public float distanceBetween = 4f;
    public CircleCollider2D enemyView;

    private float distance;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Fix: Assign the CircleCollider2D component to enemyView instead of a float
        enemyView = GetComponent<CircleCollider2D>();
        if (enemyView != null)
        {
            enemyView.radius = distanceBetween; // Set the radius of the CircleCollider2D
        }
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();

        if (distance < distanceBetween)
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        }
    }
}
