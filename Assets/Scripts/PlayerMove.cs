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

    Rigidbody2D rb;
    SpriteRenderer sr;
    CanvasManager cm;

    bool unLocked;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        cm = FindFirstObjectByType<CanvasManager>();
        unLocked = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        isGrounded = Physics2D.OverlapCircle(groundCheck.position, 0.01f, groundMask);
        isKilling = Physics2D.OverlapCircle(groundCheck.position, 0.01f, killMask);

        Movement(x);
        
        if (Input.GetKey(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }
    public void Movement( float xMov)
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
            SceneManager.LoadScene("WonScreen");
        }
    }
}
