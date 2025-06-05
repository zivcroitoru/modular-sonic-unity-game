using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpSpeed = 100;
    public LayerMask groundLayer;

    private Rigidbody2D rigid;
    private Animator animator;
    private bool canDoubleJump = true;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Jump()
    {
        rigid.velocity = new Vector2(rigid.velocity.x, 0);
        rigid.AddForce(Vector2.up * jumpSpeed);

        if (animator != null)
            animator.SetTrigger("Jump");
    }

    void Update()
    {
        bool isGrounded = transform.IsGrounded(groundLayer);

        if (isGrounded)
            canDoubleJump = true;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isGrounded)
            {
                Jump();
            }
            else if (canDoubleJump)
            {
                Jump();
                canDoubleJump = false;
            }
        }
    }
}
