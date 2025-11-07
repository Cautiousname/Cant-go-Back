// ============================================
// [EnemyController.cs]
// Role : 적의 상태(HP, Ground, Move 등)
// Input : EnemyController (상태 갱신)
// Output : UIManager (HP 표시), GameManager (죽음 알림)
// Event : OnHealthChanged, OnEnemyDead
// ============================================

using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [Header("Patrol Points")]
    public Transform pointA;
    public Transform pointB;

    [Header("Player Settings")]
    public Transform player;
    public float detectionRange = 5f;

    [Header("Movement Speeds")]
    public float patrolSpeed = 2f;
    public float chaseSpeed = 3f;

    private Vector3 target;

    void Start()
    {
        // 순찰 시작 위치 설정
        if (pointB != null)
            target = pointB.position;
        else
            target = transform.position;

        // 플레이어 자동 탐색
        if (player == null)
        {
            GameObject playerObj = GameObject.FindWithTag("Player");
            if (playerObj != null)
                player = playerObj.transform;
        }
    }

    void Update()
    {
        if (player != null)
        {
            float distanceToPlayer = Vector3.Distance(transform.position, player.position);

            if (distanceToPlayer <= detectionRange)
            {
                ChasePlayer();
            }
            else
            {
                Patrol();
            }
        }
        else
        {
            Patrol();
        }
    }

    void Patrol()
    {
        if (pointA == null || pointB == null)
            return;

        // 이동
        transform.position = Vector3.MoveTowards(transform.position, target, patrolSpeed * Time.deltaTime);

        // 목표점 도달 시 반대점으로 변경
        if (Vector3.Distance(transform.position, target) < 0.1f)
        {
            target = target == pointA.position ? pointB.position : pointA.position;
        }

        // Sprite flip (좌우 반전)
        if (target.x > transform.position.x)
            transform.localScale = new Vector3(1, 1, 1);
        else
            transform.localScale = new Vector3(-1, 1, 1);
    }

    void ChasePlayer()
    {
        // 플레이어 방향
        Vector3 direction = (player.position - transform.position).normalized;

        // 이동
        transform.position = Vector3.MoveTowards(transform.position, player.position, chaseSpeed * Time.deltaTime);

        // Sprite flip
        if (direction.x > 0)
            transform.localScale = new Vector3(1, 1, 1);
        else
            transform.localScale = new Vector3(-1, 1, 1);
    }
}
