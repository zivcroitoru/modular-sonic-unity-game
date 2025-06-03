using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour
{
    public float jumpSpeed = 100;
    private bool isJumping = false;
    private Rigidbody2D rigid;
    private PlayerAnimator animator;
    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        animator = GetComponent<PlayerAnimator>();
    }

    private void Jump()
    {
        rigid.velocity = Vector3.zero;
        rigid.AddForce(new Vector2(0, jumpSpeed));
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (transform.IsGrounded(LayerMask.GetMask("Default")))
                Jump();
            animator.TriggerJump();
        }
    }
}
