using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    [SerializeField] private float lerpSpeed = 3;

    private void Start()
    {
        player = GameManager.instance.player.transform;
    }

    private void Update()
    {
        UpdateCameraPosition();
    }

    private void UpdateCameraPosition()
    {
        Vector3 playerPos = player.position;
        Vector3 newPos = transform.position;

        newPos.x = Mathf.Lerp(transform.position.x, playerPos.x, lerpSpeed * Time.deltaTime);
        newPos.y = Mathf.Lerp(transform.position.y, playerPos.y, lerpSpeed * Time.deltaTime);

        transform.position = newPos;
    }
}
