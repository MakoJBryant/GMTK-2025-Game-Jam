using UnityEngine;
using UnityEngine.UI;
using System.Reflection;
using UnityEngine.SceneManagement;
using TMPro; // You need to add this line for TextMeshPro

public class UIController : MonoBehaviour
{
    public static UIController Instance;

    [Header("UI Elements")]
    public TMP_Text healthText; // Changed from Text to TMP_Text
    public TMP_Text shieldText; // Changed from Text to TMP_Text
    public TMP_Text enemyCountText; // Changed from Text to TMP_Text

    private PlayerStats stats;
    private FieldInfo currentHealthField;
    private FieldInfo maxHealthField;
    private FieldInfo shieldField;
    private FieldInfo maxShieldField;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject); // Prevent duplicates
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject); // Persist through scene loads

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void OnDestroy()
    {
        if (Instance == this)
            SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    private void Start()
    {
        TryFindPlayerStats();
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        TryFindPlayerStats();
    }

    private void TryFindPlayerStats()
    {
        stats = FindFirstObjectByType<PlayerStats>();

        if (stats == null) return;

        currentHealthField = typeof(PlayerStats).GetField("currentHealth", BindingFlags.NonPublic | BindingFlags.Instance);
        maxHealthField = typeof(PlayerStats).GetField("maxHealth", BindingFlags.NonPublic | BindingFlags.Instance);
        shieldField = typeof(PlayerStats).GetField("shield", BindingFlags.NonPublic | BindingFlags.Instance);
        maxShieldField = typeof(PlayerStats).GetField("maxShield", BindingFlags.NonPublic | BindingFlags.Instance);
    }

    private void Update()
    {
        if (stats == null) return;

        int currentHealth = (int)currentHealthField.GetValue(stats);
        int maxHealth = (int)maxHealthField.GetValue(stats);
        int shield = (int)shieldField.GetValue(stats);
        int maxShield = (int)maxShieldField.GetValue(stats);

        // Update the health and shield UI to display numbers
        healthText.text = $"{currentHealth} / {maxHealth}";
        shieldText.text = $"{shield} / {maxShield}";
    }
}