using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float speed = 5f;

    [Header("Ground Check")]
    public LayerMask groundLayer;

    private Rigidbody2D rigid;
    private float direction;
    private Animator animator;

    public bool IsGrounded { get; private set; }

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

    }

    void FixedUpdate()
    {
        // Ground check ray from halfway down the sprite
        IsGrounded = transform.IsGrounded(groundLayer);
        if (IsGrounded)
        {
            animator.SetBool("isGrounded", true);
        }
        else
        {
            animator.SetBool("isGrounded", false);
        }
        // Movement
        direction = Input.GetAxis("Horizontal");
        rigid.velocity = new Vector2(direction * speed, rigid.velocity.y);
        animator.SetFloat("speed", Mathf.Abs(direction * speed));

        // Flip sprite
        if (direction != 0)
            transform.localScale = new Vector3(direction > 0 ? 1 : -1, 1, 1);
    }
}
