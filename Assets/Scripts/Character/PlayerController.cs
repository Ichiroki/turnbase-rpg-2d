using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;
    private Animator animator;
    private Vector2 movement;

    public SpeechBubble dialogueBubble;
    
    private SpriteRenderer sprite;

    public float lastMoveX;
    public float lastMoveY;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        transform.position = GameProgress.Instance.playerSpawnPosition;

        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
        dialogueBubble = GetComponent<SpeechBubble>();
    }

    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if (movement.sqrMagnitude > 0)
        {
            lastMoveX = movement.x;
            lastMoveY = movement.y;
        }

        if (movement.x > 0.1f)
        {
            sprite.flipX = false;
        } 
        else if(movement.x < -0.1f)
        {
            sprite.flipX = true;
        }


        // Perpindahan Idle -> Walk
        animator.SetFloat("speed", movement.sqrMagnitude);

        // Perubahan arah untuk walk animation
        animator.SetFloat("moveY", movement.y);
        animator.SetFloat("moveX", movement.x);

        // Perubahan nilai arah terakhir player bergerak untuk menjalankan idle animation tergantung arah terakhir player bergerak
        animator.SetFloat("lastMoveX", lastMoveX);
        animator.SetFloat("lastMoveY", lastMoveY);
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}
