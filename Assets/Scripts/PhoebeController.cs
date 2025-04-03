using UnityEngine;
using UnityEngine.InputSystem;

public class PhoebeController : MonoBehaviour
{
    public float jumpForce = 1.2f;
    private float fastAnimationTimer;
    public float animationSpeed = 1f;
    public float fastAnimationDuration = 0.3f;
    public float fastAnimationSpeed = 3f;
    private Rigidbody2D rb;
    private float defaultGravity;
    private Animator anim;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        defaultGravity = rb.gravityScale;
    }

    void Update(){
        if (GameState.gameOver)
            return;

        if (Mouse.current.leftButton.wasPressedThisFrame)
        {
            rb.linearVelocity = Vector2.up * jumpForce;
            fastAnimationTimer = fastAnimationDuration;
            anim.speed = fastAnimationSpeed;
        }

        if(fastAnimationTimer > 0f)
        {
            fastAnimationTimer -= Time.deltaTime;
        }
        else
        {
            anim.speed = animationSpeed;
        }
    }

    void FixedUpdate()
    {
        float tiltAngle = rb.linearVelocity.y * 10;
        tiltAngle = Mathf.Clamp(tiltAngle, -20, 20);
        transform.rotation = Quaternion.Euler(0, 0, tiltAngle);
    }

    private void GameOver()
    {
        GameState.gameOver = true;
        rb.gravityScale = 0f;
        rb.linearVelocity = Vector2.zero;
        anim.speed = 0f;
    }

    private void Revive()
    {
        GameState.gameOver = false;
        rb.gravityScale = defaultGravity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameOver();
    }
}
