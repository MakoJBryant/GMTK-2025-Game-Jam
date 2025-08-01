using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class ShieldRegenerator : MonoBehaviour
{
    private SpriteRenderer spriteRenderer;

    [SerializeField] private float opacityIncrement = .1f;
    private float defaultOpacity;
    private bool shouldIncreaseOpacity = false;
    public bool ShouldIncreaseOpacity => shouldIncreaseOpacity;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        defaultOpacity = spriteRenderer.color.a;
    }

    private void Update()
    {
        if (shouldIncreaseOpacity)
        {
            Color color = spriteRenderer.color;

            if (color.a <= defaultOpacity)
            {
                color.a += opacityIncrement * Time.deltaTime;
            }
            else
            {
                shouldIncreaseOpacity = false;
            }

            spriteRenderer.color = color;
        }
    }

    public void ShieldCooldownBehavior()
    {
        Color color = spriteRenderer.color;
        color.a = 0;
        spriteRenderer.color = color;
        shouldIncreaseOpacity = true;
    }
}
