using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public LayerMask groundLayer;
    public float raycastDistance = 0.5f;
    public Vector2 resetPosition;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool facingRight = true;
    public ParticleSystem dust;
    private bool controlEnabled;

    public Animator squashStretchAnimator;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        controlEnabled = true;
        resetPosition = Vector2.zero;
    }

    private void Update()
    {
        if (!controlEnabled) {
            return;
        }
        moveSpeed = 5f * Mathf.Abs(transform.localScale.y);
        jumpForce = 5f * transform.localScale.y;
        rb.gravityScale = transform.localScale.y;
        float moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (moveInput > 0 && !facingRight)
            Flip();
        else if (moveInput < 0 && facingRight)
            Flip();

        isGrounded = IsGrounded();

        if (isGrounded && (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.Space)))
        {
            squashStretchAnimator.SetTrigger("Jump");
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            playDust();
        }
        if (Input.GetKeyDown("r")) {
            transform.position = resetPosition;
            if (!facingRight) {
                transform.localScale = new Vector3(-1,1,1);
            } else {
                transform.localScale = Vector3.one;
            }
            rb.velocity = Vector2.zero;
        }
    }

    private bool IsGrounded()
    {
        squashStretchAnimator.SetTrigger("Land");
        raycastDistance = 0.5f * transform.localScale.y;
        RaycastHit2D hit = Physics2D.Raycast(transform.position, Vector2.down, raycastDistance, groundLayer);
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

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Danger"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
