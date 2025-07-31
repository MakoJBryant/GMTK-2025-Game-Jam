using UnityEngine;

public class LookAtMouse : MonoBehaviour
{
    private Transform m_transform;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_transform = this.transform;
    }

    private void Mouse()
    {
        Vector2 direction = Camera.main.ScreenToWorldPoint(Input.mousePosition) - m_transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);
        m_transform.rotation = rotation;
    }

    // Update is called once per frame
    void Update()
    {
        Mouse();
    }
}
