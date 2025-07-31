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
    private bool isLunging = false;

    void Start()
    {
        player = Game_Manager.instance.player.gameObject;
    }

    void Update()
    {
        if (!isLunging)
        {
            Vector3 direction = (Game_Manager.instance.player.transform.position - transform.position).normalized;
            transform.position += direction * speed * Time.deltaTime;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isLunging)
        {
            StartCoroutine(Lunge());
        }
    }


    private IEnumerator Lunge()
    {
        isLunging = true;

        yield return new WaitForSeconds(windUp);
        float timer = 0f;

        while (timer < lungeDuration)
        {
            Vector3 direction = (player.transform.position - transform.position).normalized;
            transform.position += direction * lungeSpeed * Time.fixedDeltaTime;
            timer += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        isLunging = false;
    }
}

 