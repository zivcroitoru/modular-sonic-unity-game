using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private float direction;
    public float speed = 5;
    private Rigidbody2D rigid;
    private Animator _animator;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        direction = Input.GetAxis("Horizontal");
        _animator.SetBool("IsInAir", !PlayerJump.isGrounded);
        _animator.SetBool("IsWalking", direction != 0 && PlayerJump.isGrounded);

        if (direction != 0 && rigid != null)
        {
            rigid.velocity = new Vector2(direction * speed, rigid.velocity.y);
            transform.localScale = new Vector3(direction > 0 ? 1 : -1, 1, 1);
        }
    }
}