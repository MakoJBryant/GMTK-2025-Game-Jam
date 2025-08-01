using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyScript : MonoBehaviour
{
    private Player player;
    private Transform target;
    private NavMeshAgent agent;

    [SerializeField] private float speed = 3f;
    [SerializeField] private float lungeSpeed = 8f;
    [SerializeField] private float windUp = 1f;
    [SerializeField] private float lungeDuration = 0.3f;

    private bool isLunging = false;

    private void Start()
    {
        AssignComponents();
        AssignValues();
    }

    private void Update()
    {
        MovementBehavior();
    }

    private void AssignComponents()
    {
        player = GameManager.instance.player;
        agent = GetComponent<NavMeshAgent>();
    }

    private void AssignValues()
    {
        target = player.transform;
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void MovementBehavior()
    {
        if (!isLunging)
        {
            agent.SetDestination(target.position);
            agent.speed = speed;
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isLunging)
        {
            StartCoroutine(Lunge());
        }
    }
}

 