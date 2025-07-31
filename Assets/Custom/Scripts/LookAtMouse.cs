using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    private Transform hand;
    private float maxDistanceFromOrigin = .1f;

    void Start()
    {
        hand = this.transform;
    }

    private void FollowMouseInput()
    {
        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mouseDirection = mouseWorldPos - (Vector2)hand.position;

        float angle = Mathf.Atan2(mouseDirection.y, mouseDirection.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        hand.rotation = rotation;

        Vector2 desiredPos = mouseDirection * maxDistanceFromOrigin;
        transform.localPosition = Vector2.Lerp(transform.localPosition, desiredPos, 10 * Time.deltaTime);

    }

    void Update()
    {
        FollowMouseInput();
    }
}
