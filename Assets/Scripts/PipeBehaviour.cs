using UnityEngine;

public class PipeBehaviour : MonoBehaviour
{
    private float pipeWidth;
    public float scrollSpeed = 1f;

    void Start()
    {
        pipeWidth = transform.GetChild(0).GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        if (GameState.gameOver)
            return;

        transform.position += Vector3.left * scrollSpeed * Time.deltaTime;
    }
}
