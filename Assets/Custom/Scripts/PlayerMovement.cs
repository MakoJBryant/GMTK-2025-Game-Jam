using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float sprintSpeed = 10f;
    public float dodgeSpeed = 7.5f;
    public float dodgeDuration = 0.5f;
    public float dodgeCooldown = 1f;

    public Rigidbody2D rb;

    Vector2 movement;
    Vector2 dodgeDir;

    bool isDodging = false;
    bool canDodge = true;
    float dodgeTimer = 0f;
    float cooldownTimer = 0f;

    // Update is called once per frame
    void Update()
    {
        if (!isDodging)
        {
            // Input
            movement.x = Input.GetAxisRaw("Horizontal");
            movement.y = Input.GetAxisRaw("Vertical");
            movement.Normalize(); // Normalize to prevent faster diagonal movement
        }

        if (Input.GetKeyDown(KeyCode.Space) && canDodge && movement != Vector2.zero)
        {
            isDodging = true;
            canDodge = false;
            dodgeDir = movement; // Store the direction of the dodge
            dodgeTimer = dodgeDuration; // Set the end time for the dodge
        }

        if (!canDodge)
        {
            cooldownTimer -= Time.deltaTime;
            if(cooldownTimer <= 0f)
            {
                canDodge = true; // Reset dodge ability after cooldown
            }
        }
    }

    // Fixed Timer sort of like DeltaTime
    private void FixedUpdate()
    {
        if (isDodging)
        {
            rb.MovePosition(rb.position + dodgeDir * dodgeSpeed * Time.fixedDeltaTime);
            dodgeTimer -= Time.fixedDeltaTime;
            if (dodgeTimer <= 0)
            {
                isDodging = false;
                cooldownTimer = dodgeCooldown;
            }
        }
        else
        {
            float currentSpeed = Input.GetKey(KeyCode.LeftShift) ? sprintSpeed : moveSpeed;
            rb.MovePosition(rb.position + movement * currentSpeed * Time.fixedDeltaTime);
        }

    }
}
