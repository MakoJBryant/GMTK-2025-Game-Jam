using UnityEngine;
using UnityEngine.UI;
using System.Reflection;

public class UIController : MonoBehaviour
{
    public Image healthBar;
    public Image shieldBar;

    private PlayerStats stats;

    private FieldInfo currentHealthField;
    private FieldInfo maxHealthField;
    private FieldInfo shieldField;
    private FieldInfo maxShieldField;

    private void Start()
    {
        stats = FindFirstObjectByType<PlayerStats>();

        // Cache the field info using reflection
        currentHealthField = typeof(PlayerStats).GetField("currentHealth", BindingFlags.NonPublic | BindingFlags.Instance);
        maxHealthField = typeof(PlayerStats).GetField("maxHealth", BindingFlags.NonPublic | BindingFlags.Instance);
        shieldField = typeof(PlayerStats).GetField("shield", BindingFlags.NonPublic | BindingFlags.Instance);
        maxShieldField = typeof(PlayerStats).GetField("maxShield", BindingFlags.NonPublic | BindingFlags.Instance);
    }

    private void Update()
    {
        if (stats == null) return;

        // Read private values via reflection
        int currentHealth = (int)currentHealthField.GetValue(stats);
        int maxHealth = (int)maxHealthField.GetValue(stats);
        int shield = (int)shieldField.GetValue(stats);
        int maxShield = (int)maxShieldField.GetValue(stats);

        float healthPercent = (float)currentHealth / maxHealth;
        float shieldPercent = (float)shield / maxShield;

        healthBar.fillAmount = healthPercent;
        shieldBar.fillAmount = shieldPercent;
    }
}
