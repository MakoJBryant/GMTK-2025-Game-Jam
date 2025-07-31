using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager instance;

    public Player player;

    private void Awake()
    {
        instance = this;
    }
}
