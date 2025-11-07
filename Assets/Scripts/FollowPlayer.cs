// ============================================
// [FollowPlayer.cs]
// Role    : 플레이어를 따라다니는 카메라
// Input   : Unity Input System
// Output  : Transform (위치 갱신)
// Depends : None
//============================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public float cameraSpeed = 5.0f;

    public Transform player;

    private void Update()
    {
        // 2D플레이어의 위치를 따라 카메라 위치 갱신
        Vector3 targetPosition = new Vector3(player.position.x, player.position.y, transform.position.z);
        transform.position = Vector3.Lerp(transform.position, targetPosition, cameraSpeed * Time.deltaTime);
    }
}
