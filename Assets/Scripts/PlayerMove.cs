using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMove : MonoBehaviour
{

    [Header("movimiento")]
    public float speed;
    public float jumpForce;

    [Header("condicion salto")]
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
    Animator anim;

    [Header("salto")]

    int jumpCount; 
    public int maxJumps = 2; 

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        cm = FindFirstObjectByType<CanvasManager>();
        anim = GetComponent<Animator>();
        jumpCount = 0; 
    }

  
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
            jumpCount = 0; 
        }

        PhysicsChange();

        anim.SetFloat("Speed", Mathf.Abs(x));
        anim.SetBool("IsGrounded", isGrounded);
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
        jumpCount++; 
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
