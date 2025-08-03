/*
PURPOSE:
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

    void Awake()
    {
        // Singleton pattern
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
            return;
        }
        Instance = this;
        //DontDestroyOnLoad(this.gameObject);
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
    }
}
