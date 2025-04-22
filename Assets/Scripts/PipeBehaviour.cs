using UnityEngine;

public class PipeBehaviour : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 1f;
    public float verticalAmplitude = 0.1f;
    public float verticalFrequency = 0.5f;
    public bool isMoving;
    private Vector3 startPosition;

    void Start()
    {
        startPosition = transform.position;
    }

    void Update()
    {
        if (GameController.Instance.gameOver || GameController.Instance.stopScrolling)
            return;

        transform.position += Vector3.left * scrollSpeed * Time.deltaTime;

        if (isMoving)
        {
            float newY = startPosition.y + Mathf.Sin(Time.time * verticalFrequency * 2 * Mathf.PI) * verticalAmplitude;
            transform.position = new Vector3(transform.position.x, newY, transform.position.z);
        }

        if (transform.position.x < -1)
        {
            Destroy(gameObject);
        }
    }
}
