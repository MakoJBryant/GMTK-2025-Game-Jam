using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float sprintSpeed = 10f;
    public float dodgeSpeed = 7.5f;
    public float dodgeDuration = 0.5f;
    public float dodgeCooldown = 1f;

    Vector3 movementDirection;
    Vector3 dodgeDirection;

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
            movementDirection.x = Input.GetAxisRaw("Horizontal");
            movementDirection.y = Input.GetAxisRaw("Vertical");
            movementDirection.Normalize(); // Normalize to prevent faster diagonal movement
        }

        if (Input.GetKeyDown(KeyCode.Space) && canDodge && movementDirection != Vector3.zero)
        {
            isDodging = true;
            canDodge = false;
            dodgeDirection = movementDirection; // Store the direction of the dodge
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

        if (isDodging)
        {
            transform.position += dodgeDirection * dodgeSpeed * Time.deltaTime;
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
            transform.position += movementDirection * currentSpeed * Time.deltaTime;
        }
    }
}
