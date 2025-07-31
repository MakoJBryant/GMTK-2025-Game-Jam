/*
Activates/deactivates UI panels
Can be accessed globally (singleton pattern)
Provides simple methods for switching screens
*/

#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class QuitGame : MonoBehaviour
{
    public void Quit()
    {
#if UNITY_EDITOR
        EditorApplication.isPlaying = false;  // Stop play mode in Editor
#else
        Application.Quit();  // Quit in builds
#endif
        Debug.Log("Quit Game");
    }
}


public class UIManager : MonoBehaviour
{
    public static UIManager Instance { get; private set; }

    [Header("UI Panels")]
    public GameObject titleScreen;
    public GameObject hud;
    public GameObject deathScreen;
    public GameObject loopSummaryScreen;
    public GameObject pauseMenu;

    void Awake()
    {
        // Singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        DontDestroyOnLoad(this.gameObject);
    }

    void Start()
    {
        ShowTitleScreen();
    }

    public void ShowTitleScreen()
    {
        SetAllInactive();
        titleScreen?.SetActive(true);
    }

    public void ShowHUD()
    {
        SetAllInactive();
        hud?.SetActive(true);
    }

    public void ShowDeathScreen()
    {
        SetAllInactive();
        deathScreen?.SetActive(true);
    }

    public void ShowLoopSummary()
    {
        SetAllInactive();
        loopSummaryScreen?.SetActive(true);
    }

    public void TogglePause()
    {
        if (pauseMenu != null)
            pauseMenu.SetActive(!pauseMenu.activeSelf);
    }

    public void QuitGame()
    {
        Debug.Log("Quit Game called");

#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    private void SetAllInactive()
    {
        titleScreen?.SetActive(false);
        hud?.SetActive(false);
        deathScreen?.SetActive(false);
        loopSummaryScreen?.SetActive(false);
        pauseMenu?.SetActive(false);
    }
}
