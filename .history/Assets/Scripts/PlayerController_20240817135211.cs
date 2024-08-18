using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public LayerMask groundLayer;
    public float raycastDistance = 0.5f;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool facingRight = true;
<<<<<<< HEAD
    public ParticleSystem dust;
=======
    private bool controlEnabled;
>>>>>>> 49a21400a6eaf16edc5304ce7892bcbf80d30538

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enabled = true;
    }

    private void Update()
    {
        if (!controlEnabled) {
            return;
        }
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (moveInput > 0 && !facingRight)
            Flip();
        else if (moveInput < 0 && facingRight)
            Flip();

        isGrounded = IsGrounded();

        if (isGrounded && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            playDust();
        }
    }

    private bool IsGrounded()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, raycastDistance, groundLayer);
        Debug.DrawRay(transform.position, Vector2.down * raycastDistance, Color.red);
        return hit.collider != null;
    }

    private void Flip()
    {
        playDust();
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;
    }

    public void playDust() {
        dust.Play();   
    }
    private void Control(bool enable) {
        controlEnabled = enable;
    }
}
