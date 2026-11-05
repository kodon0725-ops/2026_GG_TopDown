using UnityEngine;
using UnityEngine.InputSystem;

public class TopDownPlayer : MonoBehaviour
{
    public float moveSpeed = 4f;
    public float frameTime = 0.15f;
    public Sprite[] downSprites;
    public Sprite[] upSprites;
    public Sprite[] leftSprites;
    public Sprite[] rightSprites;

    private Vector2 moveInput;
    private Vector2 facingDir = Vector2.down;
    private Rigidbody2D rb;
    private SpriteRenderer sr;
    private Sprite[] currentSprites;
    private int frameIndex = 0;
    private float frameTimer = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        currentSprites = downSprites;
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
        if (moveInput != Vector2.zero) { facingDir = moveInput; }
    }

    void Update()
    {
        rb.linearVelocity = moveInput * moveSpeed;

        if (Mathf.Abs(facingDir.x) > Mathf.Abs(facingDir.y))
        {
            currentSprites = facingDir.x > 0 ? rightSprites : leftSprites;
        }
        else
        {
            currentSprites = facingDir.y > 0 ? upSprites : downSprites;
        }

        if (currentSprites == null || currentSprites.Length == 0) { return; }

        if (moveInput != Vector2.zero)
        {
            frameTimer += Time.deltaTime;
            if (frameTimer >= frameTime)
            {
                frameTimer = 0f;
                frameIndex = (frameIndex + 1) % currentSprites.Length;
            }
        }
        else
        {
            frameTimer = 0f;
            frameIndex = Mathf.Min(1, currentSprites.Length - 1);
        }

        if (frameIndex >= currentSprites.Length) { frameIndex = 0; }
        sr.sprite = currentSprites[frameIndex];
    }
}

