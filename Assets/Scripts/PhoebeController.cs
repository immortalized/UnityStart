using UnityEngine;

public class PhoebeController : MonoBehaviour
{
    public float jumpForce = 1.2F;
    private Rigidbody2D rb;
    private Animator anim;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void Update(){
        if (Input.GetMouseButtonDown(0))
        {
            rb.linearVelocity = Vector2.up * jumpForce;
        }
    }

    void FixedUpdate()
    {
        float tiltAngle = rb.linearVelocity.y * 10;
        tiltAngle = Mathf.Clamp(tiltAngle, -30, 30);
        transform.rotation = Quaternion.Euler(0, 0, tiltAngle);
    }
}
