using UnityEngine;

[RequireComponent(typeof(PlayerAttack))]
[RequireComponent(typeof(PlayerMovement))]
[RequireComponent(typeof(PlayerStats))]
public class Player : MonoBehaviour
{
    public PlayerAttack attack;
    public PlayerMovement movement;
    public PlayerStats stats;
    public PlayerVisualControl visualControl;
    public PlayerHand hand;

    private void Start()
    {
        attack = GetComponent<PlayerAttack>();
        movement = GetComponent<PlayerMovement>();
        stats = GetComponent<PlayerStats>();
        visualControl = GetComponentInChildren<PlayerVisualControl>();
        hand = GetComponentInChildren<PlayerHand>();
    }
}
