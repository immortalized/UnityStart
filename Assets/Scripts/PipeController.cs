using UnityEngine;

public class PipeController : MonoBehaviour
{
    private float defaultY;
    private float pipeWidth;
    private float backgroundWidth;
    private float backgroundPosition;
    public Transform background;
    public float scrollSpeed = 1f;
    public float minY = -0.5f;
    public float maxY = 0.5f;

    void Start(){
        defaultY = transform.position.y;
        SpriteRenderer pipeRenderer = transform.GetChild(0).GetComponent<SpriteRenderer>();
        pipeWidth = pipeRenderer.bounds.size.x;

        if (background != null)
        {
            backgroundWidth = background.GetComponent<SpriteRenderer>().bounds.size.x;
            backgroundPosition = background.position.x - background.GetComponent<SpriteRenderer>().bounds.size.x / 2;
        }

        transform.position = new Vector3(transform.position.x, defaultY + Random.Range(minY, maxY), transform.position.z);
    }

    void Update()
    {
        if (GameState.gameOver)
            return;

        transform.position += Vector3.left * scrollSpeed * Time.deltaTime;

        if (transform.position.x < backgroundPosition - pipeWidth)
        {
            transform.position += new Vector3(backgroundWidth * 2.5F, 0, 0);
            transform.position = new Vector3(transform.position.x, defaultY + Random.Range(minY, maxY), transform.position.z);
        }
    }

}
