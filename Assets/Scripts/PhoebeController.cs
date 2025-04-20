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
    private bool shouldStopMovement = false;
    private float defaultGravity;
    private float defaultAnimSpeed;
    private float rotationSpeed;
    private AudioSource audioSource;
    [SerializeField] private AudioClip flapSound;
    [SerializeField] private AudioClip scoreSound;
    [SerializeField] private AudioClip hitSound;
    [SerializeField] private AudioClip dieSound;
    
    
    private Animator anim;

    void Start(){
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();
        anim = GetComponent<Animator>();
        defaultGravity = rb.gravityScale;
        defaultAnimSpeed = anim.speed;
        anim.speed = 0f;
    }

    void Update(){
        if (GameController.Instance.gameOver || shouldStopMovement)
            return;

        if (Input.GetMouseButtonDown(0) || (Input.touchCount > 0 && Input.GetTouch(0).phase == UnityEngine.TouchPhase.Began))
        {
            rb.linearVelocity = Vector2.up * jumpForce;
            fastAnimationTimer = fastAnimationDuration;
            anim.speed = fastAnimationSpeed;
            audioSource.PlayOneShot(flapSound);
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
        if(rb.linearVelocity.y > 0)
        {
            rotationSpeed = 10f;
        } else
        {
            rotationSpeed = 20f;
        }

        transform.rotation = Quaternion.Euler(0, 0, Mathf.Clamp(rb.linearVelocity.y * rotationSpeed, -90, 10));
    }

    public void Die()
    {
        rb.bodyType = RigidbodyType2D.Static;
        anim.speed = 0f;
    }

    public void Revive()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        rb.gravityScale = defaultGravity;
        anim.speed = defaultAnimSpeed;
        shouldStopMovement = false;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Ground"))
        {
            if(!shouldStopMovement)
            {
                audioSource.PlayOneShot(hitSound);
            }
            GameController.Instance.GameOver();
            Die();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("ScoreTrigger"))
        {
            GameController.Instance.AddScore(1);
            audioSource.PlayOneShot(scoreSound);
        }
        if(collision.CompareTag("Pipe") || collision.CompareTag("Barrier"))
        {
            if(!shouldStopMovement)
            {
                audioSource.PlayOneShot(hitSound);
                audioSource.PlayOneShot(dieSound);
            }
            shouldStopMovement = true;
            GameController.Instance.stopScrolling = true;
        }
    }
}
