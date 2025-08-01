using UnityEngine;
using UnityEngine.Rendering;

public class PlayerVisualControl : MonoBehaviour
{
    [SerializeField] private float feedbackSpeed = 15f;
    [SerializeField] private float feedbackTime = .1f;
    [SerializeField] private Color desiredColor;

    private SpriteRenderer spriteRenderer;
    private float timeGoal = Mathf.Infinity;
    private Color defaultColor = Color.white;

    public void ShowColorFeedback(Color color, float speed, float time)
    {
        desiredColor = color;
        feedbackSpeed = speed;
        feedbackTime = time;
        timeGoal = Time.time + feedbackTime;
    }

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        desiredColor = defaultColor;
    }

    private void Update()
    {
        if (Time.time > timeGoal)
        {
            desiredColor = defaultColor;
        }

        Color currentColor = spriteRenderer.color;
        currentColor = Color.Lerp(currentColor, desiredColor, feedbackSpeed * Time.deltaTime);
        spriteRenderer.color = currentColor;
    }

}
