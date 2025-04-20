using UnityEngine;

public class ScrollBehaviour : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 0.85f;
    private Vector2 startPos;

    void Start()
    {
        SpriteRenderer groundRenderer = GetComponent<SpriteRenderer>();
        startPos = new Vector2(transform.position.x, transform.position.y);
    }

    void Update()
    {
        if (GameController.Instance.gameOver || GameController.Instance.stopScrolling)
            return;

        transform.position += Vector3.left * scrollSpeed * Time.deltaTime;

        if (transform.position.x < -0.72)
        {
            transform.position = new Vector3(startPos.x, startPos.y, 0);
        }
    }
}
