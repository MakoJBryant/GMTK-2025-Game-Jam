using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    public Player player;
    public AudioManager audioManager;
    public RoomManager room;
    public GameData data;

    private void Awake()
    {
        CreateInstance();
        data = data ?? new GameData();
    }

    private void CreateInstance()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }

        DontDestroyOnLoad(gameObject);
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
