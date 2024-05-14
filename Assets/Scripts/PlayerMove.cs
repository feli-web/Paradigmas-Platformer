using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    
    public float speed;
    public float jumpForce;

    public bool isGrounded;

    Rigidbody2D rb;
    SpriteRenderer sr;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float y = Input.GetAxis("Vertical");
        
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
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
