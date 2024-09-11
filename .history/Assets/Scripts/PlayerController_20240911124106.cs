using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 5f;
    public LayerMask groundLayer;
    public float raycastDistance = 0.5f;
    public Vector2 resetPosition;
    public GameObject currScalePoint;
    public bool canOut = true;
    public bool canIn = true;
    public bool direction;

    private Rigidbody2D rb;
    private bool isGrounded;
    private bool facingRight = true;
    public ParticleSystem dust;
    private bool controlEnabled;
    private static int currLevel;
    private bool canJump;

    public Animator squashStretchAnimator;

    private void Start()
    {
        De
        rb = GetComponent<Rigidbody2D>();
        controlEnabled = true;
        resetPosition = Vector2.zero;
        currLevel = SceneManager.GetActiveScene().buildIndex - 1;
        canJump = false;
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
            Reset();
            // transform.position = resetPosition;
            // if (!facingRight) {
            //     transform.localScale = new Vector3(-1,1,1);
            // } else {
            //     transform.localScale = Vector3.one;
            // }
            // rb.velocity = Vector2.zero;
        }
        Vector3 viewportPos = Camera.main.WorldToViewportPoint(transform.position);
        if (viewportPos.x < 0 || viewportPos.x > 1 || viewportPos.y < 0 || viewportPos.y > 1) {
            Reset();
        }
    }

    private bool IsGrounded()
    {
        // raycastDistance = 0.5f * transform.localScale.y;
        // Vector2 originLeft = new Vector2(transform.position.x - transform.localScale.x / 2, transform.position.y);
        // Vector2 originCenter = new Vector2(transform.position.x, transform.position.y);
        // Vector2 originRight = new Vector2(transform.position.x + transform.localScale.x / 2, transform.position.y);
        // RaycastHit2D hitLeft = Physics2D.Raycast(originLeft, Vector2.down, raycastDistance, groundLayer);
        // RaycastHit2D hitCenter = Physics2D.Raycast(originCenter, Vector2.down, raycastDistance, groundLayer);
        // RaycastHit2D hitRight = Physics2D.Raycast(originRight, Vector2.down, raycastDistance, groundLayer);
        // return hitLeft.collider != null || hitCenter.collider != null || hitRight.collider != null;
        return canJump;
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
    public void Control(bool enable) {
        controlEnabled = enable;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        squashStretchAnimator.SetTrigger("Land");
        if (collision.gameObject.CompareTag("Ground"))
        {
            squashStretchAnimator.SetTrigger("Land");
        }
        if (collision.gameObject.CompareTag("Danger"))
        {
            //sfx
            AudioManager.Instance.PlaySFX("Death");
            Reset();
        }
        if (!currScalePoint) return;
        if (direction) {    
            canIn = false;
        } else {
            canOut = false;
        }
    }
    void OnCollisionExit2D(Collision2D other) {
        canOut = true;
        canIn = true;
    }
    void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.CompareTag("End")) {
            End();
        }
    }
    void Reset() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    void End() {
        //play animations?
        
        currLevel++;
        if (currLevel > PlayerPrefs.GetInt("maxlevel")) {
            PlayerPrefs.SetInt("maxlevel", currLevel);
        }
        SceneManager.LoadScene(currLevel + 1);
    }
    public void AllowJump(bool allow) {
        canJump = allow;
    }
}
