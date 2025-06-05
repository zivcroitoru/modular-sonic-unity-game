using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpSpeed = 100;
    private Rigidbody2D rigid;
    private PlayerMovement movement;
    private Animator animator;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        movement = GetComponent<PlayerMovement>();
        animator = GetComponent<Animator>();
    }

    private void Jump()
    {
        rigid.velocity = Vector2.zero;
        rigid.AddForce(Vector2.up * jumpSpeed);

        if (animator != null)
            animator.SetTrigger("Jump");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (movement != null && movement.IsGrounded)
                Jump();
        }
    }
}
