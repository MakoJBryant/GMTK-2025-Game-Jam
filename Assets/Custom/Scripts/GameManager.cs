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
        bool enterSacrifice = false;
        player.movement.LockControls(true);
        data.round++;
        if (data.round >= data.roundLimit)
        {
            enterSacrifice = true;
            data.round = 0;
            data.IncreaseDifficulty();
        }
        StartCoroutine(player.visualControl.ExitScene(enterSacrifice));
    }

    public void HandleDeath()
    {
        data.IncreaseDifficulty();
        LoadRandomFightScene();
    }

    public void LoadRandomFightScene()
    {
        SceneManager.LoadScene("Level " + Random.Range(1, data.fightSceneCount));
    }

    public void LoadStartScene()
    {
        SceneManager.LoadScene("StartScene");
    }

    public void LoadSacrificeScene()
    {
        SceneManager.LoadScene("SacrificeScene");
    }
}
