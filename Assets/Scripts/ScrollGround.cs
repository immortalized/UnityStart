using UnityEngine;

public class ScrollGround : MonoBehaviour
{
    public float scrollSpeed = 1f;
    private float groundWidth;
    
    public Transform background; // Drag your background object here in Unity Inspector
    public bool isSecondGround = false; // Add a checkbox to the Inspector

    void Start()
    {
        SpriteRenderer groundRenderer = GetComponent<SpriteRenderer>();
        groundWidth = groundRenderer.bounds.size.x; // Get ground width
        
        // Set ground width equal to background width
        if (background != null)
        {
            float backgroundWidth = background.GetComponent<SpriteRenderer>().bounds.size.x;
            transform.localScale = new Vector3(backgroundWidth / groundWidth, 1, 1);
            groundWidth = backgroundWidth; // Update ground width to match background

            if(isSecondGround){
                transform.position = new Vector3(backgroundWidth, transform.position.y, transform.position.z);
            }
        }
    }

    void Update()
    {
        transform.position += Vector3.left * scrollSpeed * Time.deltaTime;

        // Loop the ground when it moves out of view
        if (transform.position.x < -groundWidth)
        {
            transform.position += new Vector3(groundWidth * 2, 0, 0);
        }
    }
}
