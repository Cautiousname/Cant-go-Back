// ============================================
// [Enemy.cs]
// 플레이어와 충돌시 데미지 10
// 불러온것:Rigidbody2D
// ============================================
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Enemy : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
       // Patrol();
    }
    /// <summary> 적 좌우 이동 </summary>
    void Patrol() 
    {
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        
        //TODO:벽/끝 감지 시 방향 전환 로직
    }

    /// <summary> 플레이어와 충돌시 데미지 10 </summary>
    /// <param name="collision"> 물리박스 </param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerStatus>().TakeDamage(10);
        }
    }
}