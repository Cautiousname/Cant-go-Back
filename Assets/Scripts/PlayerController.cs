// ============================================
// [PlayerController.cs]
// Role    : 입력 처리 및 이동 물리 제어
// Input   : Unity Input System
// Output  : PlayerStatus (상태 갱신), PlayerAnimation (시각적 피드백)
// Depends : Rigidbody2D, Animator
// ============================================

using UnityEngine;


public class PlayerController : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    private Rigidbody2D rb;
    private PlayerStatus status;
    private PlayerAnimation anim;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        status = GetComponent<PlayerStatus>();
        anim = GetComponent<PlayerAnimation>();
    }

    void Update()
    {
        HandleInput();
        anim.UpdateAnimation(status);
    }

    void HandleInput() // 입력 처리
    {
        float move = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(move * moveSpeed, rb.velocity.y);

        if (Input.GetButtonDown("Jump") && status.isGrounded)
        {
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            status.isGrounded = false;
        }
        status.isMoving = move != 0;
    }
}