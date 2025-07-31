using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public GameObject Wind;
    bool isAttacking = false;
    float atkDuration = 0.5f; // Duration of the attack animation
    float atkTimer = 0f; // Timer to track the attack duration

    private void Update()
    {
        CheckWindTimer();

        if(Input.GetKeyDown(KeyCode.C))
        {
            OnAttack();
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

    void CheckWindTimer()
    {
        if(isAttacking)
        {
            atkTimer += Time.deltaTime;
            if (atkTimer >= atkDuration)
            {
                isAttacking = false;
                atkTimer = 0f; // Reset the timer for the next attack
                Wind.SetActive(false);
            }
        }
    }

}
