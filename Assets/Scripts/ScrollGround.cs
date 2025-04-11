using UnityEngine;

public class ScrollGround : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 1f;
    private Vector2 startPos;
    private float groundWidth;

    void Start()
    {
        SpriteRenderer groundRenderer = GetComponent<SpriteRenderer>();
        groundWidth = groundRenderer.bounds.size.x;
        startPos = new Vector2(transform.position.x, transform.position.y);
    }

    void Update()
    {
        if (GameController.Instance.gameOver)
            return;

        transform.position += Vector3.left * scrollSpeed * Time.deltaTime;

        if (transform.position.x < 0)
        {
            transform.position = new Vector3(startPos.x, startPos.y, 0);
        }
    }
}
