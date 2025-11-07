// ============================================
// [PlayerAnimation.cs]
// Role : 플레이어의 애니메이션 상태 관리
// Input : PlayerController (애니메이션 트리거)
// Output : Animator (애니메이션 재생)
// Event : OnAnimationStateChanged
// ============================================

using UnityEngine;
using UnityEngine.Animations;
using System.Collections.Generic;
using System;

public class PlayerAnimation : MonoBehaviour
{
    private Animator anim;

    void Start() => anim = GetComponent<Animator>();

    public void UpdateAnimation(PlayerStatus status)
    {
        anim.SetBool("isMoving", status.isMoving);
        anim.SetBool("isGrounded", status.isGrounded);
    }
}
