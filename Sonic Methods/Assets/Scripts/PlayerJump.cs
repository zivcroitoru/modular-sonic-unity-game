using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpSpeed = 100;
    private bool isJumping = false;
    private Rigidbody2D rigid;
    private Animator _animator;
    public static bool isGrounded = true;
    [SerializeField] private bool debugIsGrounded;

    private void OnEnable()
    {
        SC_Floor.OnFloorCollision += OnFloorCollision;
    }

    private void OnDisable()
    {
        SC_Floor.OnFloorCollision -= OnFloorCollision;
    }

    void Awake()
    {
        _animator = GetComponent<Animator>();
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Jump()
    {
        if (!isJumping && isGrounded)
        {
            rigid.AddForce(new Vector2(0, jumpSpeed));
            isJumping = true;
            isGrounded = false;
            _animator.SetBool("IsWalking", false);
            _animator.SetBool("IsInAir", true);
        }
    }

    private void Update()
    {
        debugIsGrounded = isGrounded;
        if (Input.GetKeyDown(KeyCode.Space))
            Jump();
    }

    private void OnFloorCollision()
    {
        isGrounded = true;
        isJumping = false;
        _animator.SetBool("IsInAir", false);
    }
}
