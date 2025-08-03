using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private GameObject wind;
    [SerializeField] private GameObject thunder;
    [SerializeField] private float attackDuration = 0.3f; // Duration of the attack animation
    //[SerializeField] private float blastDuration = .3f;
    //[SerializeField] private float blastTimer = 0;
    [SerializeField] private float attackTimer = 0f; // Timer to track the attack duration
    //SerializeField] private bool isBlasting = false; // lmao
    [SerializeField] private bool isAttacking = false;

    //ranged
    [SerializeField] private Transform aim;
    [SerializeField] private GameObject shards;
    [SerializeField] private float fireForce = 10f;
    [SerializeField] private float fireCooldown = 0.25f; // Cooldown time between shots
    [SerializeField] private float fireTimer = 0.5f; // Timer to track the cooldown


    private void Update()
    {
        CheckAttackTimer();
        CheckInput();

        fireTimer += Time.deltaTime; // Increment the shoot cooldown timer
    }

    private void CheckAttackTimer()
    {
        if(isAttacking)
        {
            attackTimer += Time.deltaTime;
            if (attackTimer >= attackDuration)
            {
                isAttacking = false;
                attackTimer = 0f; // Reset the timer for the next attack
                wind.SetActive(false);
                thunder.SetActive(false); // Deactivate Thunder after the attack
            }
        }

/*        if (isBlasting)
        {
            blastTimer += Time.deltaTime;
            if (blastTimer >= blastDuration)
            {
                isBlasting = false;
                blastTimer = 0f;
                wind.SetActive(false);
                thunder.SetActive(false);
            }
        }*/
    }

    private void CheckInput()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && !isAttacking)
        {
            OnAttack();
        }
        if (Input.GetKeyDown(KeyCode.Q) && !isAttacking)
        {
            OnBlast();
        }
        if (Input.GetKeyDown(KeyCode.Mouse1) && !isAttacking)
        {
            OnShoot();
        }
    }

    private void OnAttack()
    {
        wind.SetActive(true);
        isAttacking = true;
    }

    private void OnBlast()
    {
        thunder.SetActive(true);
        isAttacking = true;
    }

    private void OnShoot()
    {
        if(fireTimer > fireCooldown)
        {
            fireTimer = 0f; // Reset the cooldown timer
            GameObject bullet = Instantiate(shards, aim.position, aim.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(aim.up * fireForce, ForceMode2D.Impulse);
            Destroy(bullet, 2f); // Destroy the bullet after 2 seconds
        }
    }
}
