using JetBrains.Annotations;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject Wind;
    public GameObject Thunder;
    bool isAttacking = false;
    float atkDuration = 0.3f; // Duration of the attack animation
    float atkTimer = 0f; // Timer to track the attack duration

    //ranged
    public Transform Aim;
    public GameObject Shards;
    public float fireForce = 10f;
    float shootCooldown = 0.25f; // Cooldown time between shots
    float shootTimer = 0.5f; // Timer to track the cooldown


    private void Update()
    {
        CheckAttackTimer();
        shootTimer += Time.deltaTime; // Increment the shoot cooldown timer


        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            OnAttack();
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            OnBlast();
        }
        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            OnShoot();
        }

    }
    void OnAttack()
    {
        if (!isAttacking)
        {
            Wind.SetActive(true);
            isAttacking = true;
        }
    }

    void OnBlast()
    {
        if(!isAttacking)
        {
            Thunder.SetActive(true);
            isAttacking = true;
            atkTimer = 0f; // Reset the timer for the blast attack
        }
    }

    void OnShoot()
    {
        if(shootTimer > shootCooldown)
        {
            shootTimer = 0f; // Reset the cooldown timer
            GameObject bullet = Instantiate(Shards, Aim.position, Aim.rotation);
            bullet.GetComponent<Rigidbody2D>().AddForce(Aim.up * fireForce, ForceMode2D.Impulse);
            Destroy(bullet, 2f); // Destroy the bullet after 2 seconds
        }
    }

    void CheckAttackTimer()
    {
        if(isAttacking)
        {
            atkTimer += Time.deltaTime;
            if (atkTimer >= atkDuration)
            {
                isAttacking = false;
                atkTimer = 0f; // Reset the timer for the next attack
                Wind.SetActive(false);
                Thunder.SetActive(false); // Deactivate Thunder after the attack
            }
        }
    }

}
