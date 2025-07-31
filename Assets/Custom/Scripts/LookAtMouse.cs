using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    private Transform playerTransform;
    private Transform m_transform;
    private float maxDistanceFromOrigin = .1f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_transform = this.transform;
        playerTransform = GetComponentInParent<PlayerMovement>().gameObject.transform;
    }

    private void Mouse()
    {
        Vector2 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mouseWorldPos - (Vector2)m_transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        m_transform.rotation = rotation;

        Vector2 dir = direction * maxDistanceFromOrigin;
        transform.localPosition = Vector2.Lerp(transform.localPosition, dir, 10 * Time.deltaTime);

    }

    // Update is called once per frame
    void Update()
    {
        Mouse();
    }
}
