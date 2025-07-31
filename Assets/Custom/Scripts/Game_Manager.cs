using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager instance;

    public Player player;
    //public Game_Data data;

    private void Awake()
    {
        instance = this;
        //data = new Game_Data();
    }

    void HandleWin()
    {

    }
}
