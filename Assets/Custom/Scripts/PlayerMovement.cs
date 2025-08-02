using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float sprintSpeed = 10f;
    public float dodgeSpeed = 7.5f;

    public float dodgeDuration = 0.5f;
    public float dodgeCooldown = 1f;
    private float dodgeTimer = 0f;
    private float cooldownTimer = 0f;

    private bool isDodging = false;
    private bool canDodge = true;
    private bool lockControls = false;

    private Vector3 movementDirection;
    private Vector3 dodgeDirection;

    public void LockControls(bool b) => lockControls = b;

    private void Start()
    {
        LockControls(false);
    }

    private void Update()
    {
        if (!lockControls)
            Movement();
    }

    private void Movement()
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
            if (cooldownTimer <= 0f)
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
            transform.position += currentSpeed * Time.deltaTime * movementDirection;
        }
    }
}
