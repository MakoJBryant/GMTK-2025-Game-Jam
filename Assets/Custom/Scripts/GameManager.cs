using System.Runtime.InteropServices.WindowsRuntime;
using UnityEditor.Overlays;
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
        if (instance != null && instance != this)
        {
            Destroy(gameObject); // Destroy duplicate
        }
        else
        {
            instance = this;
        }

        if (data == null)
        {
            data = new GameData();
        }
    }

    private void Start()
    {
        data.LoadData();
    }

    public void HandleWin()
    {
        bool enterSacrifice = false;
        player.movement.LockControls(true);
        data.IncrementRound();
        if (data.GetRound() >= data.roundLimit)
        {
            enterSacrifice = true;
            data.ResetRounds();
            data.IncreaseDifficulty();
        }
        StartCoroutine(player.visualControl.ExitScene(enterSacrifice));
    }

    public void HandleDeath()
    {
        StartCoroutine(player.visualControl.PlayerDeath(false));
    }

    public void HandleSacrifice()
    {
        data.IncreaseDifficulty();
        StartCoroutine(player.visualControl.PlayerDeath(true));
    }

    public void LoadGameOverScene()
    {
        SceneManager.LoadScene("TitleScene");
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
