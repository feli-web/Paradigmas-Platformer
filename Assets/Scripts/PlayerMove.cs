using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public float jumpForce;

    public Transform groundCheck;
    public bool isGrounded;
    public bool isKilling;
    public LayerMask groundMask;
    public LayerMask killMask;
    public PhysicsMaterial2D bounce;
    public PhysicsMaterial2D normal;

    Rigidbody2D rb;
    SpriteRenderer sr;
    CanvasManager cm;

    bool unLocked;
    int jumpCount; // New variable for tracking jumps
    public int maxJumps = 2; // Maximum number of jumps allowed

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        cm = FindFirstObjectByType<CanvasManager>();
        unLocked = false;
        jumpCount = 0; // Initialize jump count
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.01f, groundMask);
        isKilling = Physics2D.OverlapCircle(groundCheck.position, 0.01f, killMask);

        Movement(x);

        if (Input.GetKeyDown(KeyCode.Space) && (isGrounded || jumpCount < maxJumps))
        {
            Jump();
        }

        if (isGrounded)
        {
            jumpCount = 0; // Reset jump count when grounded
        }

        PhysicsChange();
    }

    public void Movement(float xMov)
    {
        if (xMov < 0)
        {
            sr.flipX = true;
        }
        if (xMov > 0)
        {
            sr.flipX = false;
        }

        rb.velocity = new Vector2(xMov * speed, rb.velocity.y);
    }

    public void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        jumpCount++; // Increment jump count
    }

    public void PhysicsChange()
    {
        if (isGrounded)
        {
            rb.sharedMaterial = normal;
        }
        if (!isGrounded)
        {
            rb.sharedMaterial = bounce;
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Banana"))
        {
            Destroy(collision.gameObject);
            cm.AddBanana();
        }
        if (collision.gameObject.CompareTag("Key"))
        {
            Destroy(collision.gameObject);
            unLocked = true;
        }
        if (collision.gameObject.CompareTag("Door") && unLocked == true)
        {
            int scene = SceneManager.GetActiveScene().buildIndex;
            if (SceneManager.sceneCount == scene + 1)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                SceneManager.LoadScene(scene + 1);
            }
        }
        if (collision.gameObject.CompareTag("Spike"))
        {
            Death();
        }
    }

    public void Death()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene);
    }
}
