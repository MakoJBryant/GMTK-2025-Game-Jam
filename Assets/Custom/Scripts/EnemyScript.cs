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
        Debug.Log("Lunge started");
        agent.isStopped = true; // Stop the agent to prevent it from moving during the lunge
        agent.ResetPath();
        isLunging = true;

        yield return new WaitForSeconds(windUp);
        float timer = 0f;

        Vector3 direction = (player.transform.position - transform.position).normalized;
        while (timer < lungeDuration)
        {
            transform.position += direction * lungeSpeed * Time.fixedDeltaTime;
            timer += Time.fixedDeltaTime;
            yield return new WaitForFixedUpdate();
        }

        isLunging = false;
        agent.SetDestination(target.position);
        agent.isStopped = false; // Resume the agent's movement
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && !isLunging)
        {
            Debug.Log("Enemy lunging at player!");
            StartCoroutine(Lunge());
        }
    }
}

 