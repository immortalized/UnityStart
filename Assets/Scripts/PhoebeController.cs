using UnityEngine;
using UnityEngine.InputSystem;

public class PhoebeController : MonoBehaviour
{

    [SerializeField] private PlayButtonBehaviour playButton;
    [SerializeField] private float jumpForce = 1.2f;
    private float fastAnimationTimer;
    [SerializeField] private float animationSpeed = 1f;
    [SerializeField] private float fastAnimationDuration = 0.3f;
    [SerializeField] private float fastAnimationSpeed = 3f;
    private Rigidbody2D rb;
    private float defaultGravity;
    private float defaultAnimSpeed;
    
    
    private Animator anim;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        defaultGravity = rb.gravityScale;
        defaultAnimSpeed = anim.speed;
        anim.speed = 0f;
    }

    void Update(){
        if (GameState.gameOver)
            return;

        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == UnityEngine.TouchPhase.Began))
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
        transform.rotation = Quaternion.Euler(0, 0, Mathf.Clamp(rb.linearVelocity.y * 10, -20, 20));
    }

    private void GameOver()
    {
        GameState.gameOver = true;
        rb.bodyType = RigidbodyType2D.Static;
        anim.speed = 0f;
        playButton.ShowMenu();
    }

    public void Revive()
    {
        GameState.gameOver = false;
        GameState.score = 0;
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = defaultGravity;
        anim.speed = defaultAnimSpeed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameOver();
    }
}
