using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    [Range(0, 5)]
    [SerializeField] private float lerpSpeed = 3;
    [Range(-5, 5)]
    [SerializeField] private float yOffset = 0;

    public GameObject player; // Reference to the player GameObject

    private void Update()
    {
        Vector3 playerPos = player.transform.position;
        Vector3 newPos = transform.position;

        newPos.x = Mathf.Lerp(transform.position.x, playerPos.x, lerpSpeed * Time.deltaTime);
        newPos.y = Mathf.Lerp(transform.position.y, playerPos.y, lerpSpeed * Time.deltaTime);


        newPos.y += yOffset; // Add offset

        transform.position = newPos;
    }
}
