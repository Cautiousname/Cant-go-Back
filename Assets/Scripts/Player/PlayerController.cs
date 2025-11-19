// ============================================
// [PlayerController.cs]
// 플레이어, 플랫폼 Tag 할당해서 정의해줄것
// 점프:space키 할당
// TODO:공격 A
// SA_TODO:isCused(오른쪽이동 불가) IsCused()
// 불러온것:Rigidbody2D
// ============================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerController : MonoBehaviour
{
    [Header("이동")]
    public float moveSpeed;
    public float jumpForce;
    private Rigidbody2D rb;

    [Header("상태")]
    private bool isGrounded;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        Move();
        Jump();
        Attack();
    }

    void Move() // 좌우 이동
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    void Jump() // 점프
    {   
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        }
    }
    //TODO:공격
    void Attack() //공격
    {
        
    }
    //TODO:하강

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // 바닥 충돌 체크
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
            isGrounded = false;
    }
}

