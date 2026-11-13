using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float moveSpeed = 2f;
    public float chaseRange = 5f;
    public Transform player;
    public DialogueBox dialogueBox;
    private Rigidbody2D rb;


    public Sprite[] downSprites;
    public Sprite[] upSprites;
    public Sprite[] leftSprites;
    public Sprite[] rightSprites;
    private Sprite[] currentSprites;
    private float frameTimer = 0f;
    private int frameIndex = 0;
    public float frameTime = 0.15f;
    private SpriteRenderer sr;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        currentSprites = downSprites;
    }
    void Update()
    {
        Vector2 toPlayer = player.position - transform.position;
        if (dialogueBox.isOpen || toPlayer.magnitude > chaseRange)
        {
            rb.linearVelocity = Vector2.zero;
        }
        else
        {
            rb.linearVelocity = toPlayer.normalized * moveSpeed;

            if (rb.linearVelocity.y > 1f) { currentSprites = upSprites; }
            else if (rb.linearVelocity.y < -1f) { currentSprites = downSprites; }
            else if (rb.linearVelocity.x < 0) { currentSprites = leftSprites; }
            else { currentSprites = rightSprites; }
        }
        if (rb.linearVelocity != Vector2.zero)
        {
            frameTimer -= Time.deltaTime;
            if (frameTimer <= 0f)
            {
                frameTimer = frameTime;
                frameIndex += 1;
                if (frameIndex >= currentSprites.Length) { frameIndex = 0; }
            }
        }
        else { frameIndex = 0; }
        sr.sprite = currentSprites[frameIndex];
    }
}





