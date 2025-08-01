using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager instance;

    public Player player;
    public AudioManager audioManager;
    public Room_Manager room;
    public Game_Data data;

    private void Awake()
    {
        instance = this;
        data = new Game_Data();
    }

    public void HandleWin()
    {
        data.round++;
        LoadRandomScene();
    }

    public void HandleDeath()
    {
        data.IncreaseDifficulty();
        LoadRandomScene();
    }

    public void LoadRandomScene() => SceneManager.LoadScene(Random.Range(0, SceneManager.sceneCountInBuildSettings));
}
