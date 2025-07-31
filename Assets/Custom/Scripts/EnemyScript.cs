using System.Collections;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject player; // Reference to the player GameObject
    public float speed = 3f;
    public float lungeSpeed = 8f;
    public float windUp = 1f;
    public float lungeDuration = 0.3f;
    public float pauseAfterLunge = 0.5f;

    public bool chasePlayer = true;
    private bool isAttacking = false;

    private Rigidbody2D rb;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = Game_Manager.instance.player.gameObject;
    }

    // Update is called once per frame
    void Update()
    {
        if(chasePlayer && !isAttacking)
        {
            Vector2 direction = player.transform.position - transform.position;
            direction.Normalize();
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime); 
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isAttacking)
        {
            StartCoroutine(AttackPlayer());
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            chasePlayer = false;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            chasePlayer = true; // Resume chasing the player when out of attack range
        }
    }


    private IEnumerator AttackPlayer()
    {
        // functionality to attack the player
        isAttacking = true;

        yield return new WaitForSeconds(windUp);
        Vector2 direction = (player.transform.position - transform.position).normalized;
        float timer = 0f;

        while (timer < lungeDuration)
        {
            rb.MovePosition(rb.position + direction * lungeSpeed * Time.fixedDeltaTime);
            timer += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        yield return new WaitForSeconds(pauseAfterLunge);
        isAttacking = false; // Reset attacking state after the attack is done
    }
}

 