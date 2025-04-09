using UnityEngine;

public class ScrollGround : MonoBehaviour
{
    [SerializeField] private float scrollSpeed = 1f;
    private float startScrollSpeed;
    [SerializeField] private float groundWidth;
    
    [SerializeField] private Transform background;
    [SerializeField] private bool isSecondGround = false;

    void Start()
    {
        SpriteRenderer groundRenderer = GetComponent<SpriteRenderer>();
        groundWidth = groundRenderer.bounds.size.x;
        startScrollSpeed = scrollSpeed;
        
        if (background != null)
        {
            float backgroundWidth = background.GetComponent<SpriteRenderer>().bounds.size.x;
            transform.localScale = new Vector3(backgroundWidth / groundWidth, 1, 1);
            groundWidth = backgroundWidth;

            if(isSecondGround){
                transform.position = new Vector3(backgroundWidth, transform.position.y, transform.position.z);
            }
        }
    }

    void Update()
    {
        if (GameController.Instance.gameOver)
            return;

        transform.position += Vector3.left * scrollSpeed * Time.deltaTime;

        if (transform.position.x < -groundWidth)
        {
            transform.position += new Vector3(groundWidth * 2, 0, 0);
        }
    }
}
