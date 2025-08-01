using UnityEngine;

public class PlayerHand : MonoBehaviour
{
    private float maxDistanceFromOrigin = .1f;

    private void Update()
    {
        FollowMouseInput();
    }

    private void FollowMouseInput()
    {
        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mouseDirection = mouseWorldPos - (Vector2)transform.position;

        float angle = Mathf.Atan2(mouseDirection.y, mouseDirection.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        transform.rotation = rotation;

        Vector2 desiredPos = mouseDirection * maxDistanceFromOrigin;
        transform.localPosition = Vector2.Lerp(transform.localPosition, desiredPos, 10 * Time.deltaTime);

    }
}
