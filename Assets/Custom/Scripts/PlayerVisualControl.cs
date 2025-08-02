using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerVisualControl : MonoBehaviour
{
    [SerializeField] private Sprite playerExitSprite;
    [SerializeField] private Sprite defaultSprite;
    [SerializeField] private float feedbackSpeed = 15f;
    [SerializeField] private float feedbackTime = .1f;
    [SerializeField] private float shrinkSpeed = 15f;
    [SerializeField] private Color desiredColor;

    private SpriteRenderer spriteRenderer;
    private float timeGoal = Mathf.Infinity;
    private bool isExiting = false;
    private Color defaultColor = Color.white;

    public IEnumerator ExitScene(bool enterSacrificeStage)
    {
        GameManager.instance.player.hand.gameObject.SetActive(false);
        spriteRenderer.sprite = playerExitSprite;
        yield return new WaitForSeconds(1);
        isExiting = true;
        yield return new WaitForSeconds(2);
        isExiting = false;
        if (enterSacrificeStage)
        {
            GameManager.instance.LoadSacrificeScene();
        }
        else
        {
            GameManager.instance.LoadRandomFightScene();
        }
    }

    public IEnumerator SacrificeSelf()
    {
        GameManager.instance.player.hand.gameObject.SetActive(false);
        spriteRenderer.sprite = playerExitSprite;
        yield return new WaitForSeconds(1);
        ShowColorFeedback(Color.red, 5, .25f);
        Vector3 newRotation = transform.localEulerAngles;
        newRotation.z = 90;
        transform.localEulerAngles = newRotation;
        yield return new WaitForSeconds(1);
        isExiting = true;
        yield return new WaitForSeconds(2);
        isExiting = false;
        GameManager.instance.LoadStartScene();
    }

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
        AssignValues();
    }

    private void Update()
    {
        ColorControl();
        ShrinkControl();
    }

    private void AssignValues()
    {
        spriteRenderer.sprite = defaultSprite;
        desiredColor = defaultColor;
        transform.localScale = Vector3.one;
    }

    private void ColorControl()
    {
        if (Time.time > timeGoal)
        {
            desiredColor = defaultColor;
        }

        Color currentColor = spriteRenderer.color;
        currentColor = Color.Lerp(currentColor, desiredColor, feedbackSpeed * Time.deltaTime);
        spriteRenderer.color = currentColor;
    }

    private void ShrinkControl()
    {
        if (isExiting)
        {
            Vector2 currentScale = transform.localScale;
            currentScale = Vector2.Lerp(currentScale, Vector2.zero, shrinkSpeed * Time.deltaTime);
            transform.localScale = currentScale;
        }
    }
}
