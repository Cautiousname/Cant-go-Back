// ============================================
// [PlayerController.cs]
// Role    : 입력 처리 및 이동 물리 제어
// Input   : Unity Input System
// Output  : PlayerStatus (상태 갱신), PlayerAnimation (시각적 피드백)
// Depends : Rigidbody2D, Animator
/*  
    --is assigned but its value is never used 오류--
    상황	       원인	              해결
    값만 넣고 안 씀	대입만 하고 사용 X	코드에서 변수 활용
    테스트용 코드	미사용 변수	        삭제 또는 _
    컴파일러 경고 제거 원함	경고 219	pragma로 감싸기
    
*/
// ============================================

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerController : MonoBehaviour
{
    bool inputRight = false; bool inputLeft = false; 
    //이동 방향 어느쪽인지
    public float jumpPower = 45; bool inputJump = false;

    public float moveSpeed = 10;

    Rigidbody2D rigid2D;
    PlayerStatus status;
    InputManager inputManager;
    //각종 컴포넌트 선언
    void Start()
    {
        rigid2D = GetComponent<Rigidbody2D>();
        status = GetComponent<PlayerStatus>();
        inputManager = GetComponent<InputManager>();

        //각종 컴포넌트 받아오기
    }

    void Update()
    {
        MoveLeft();
        MoveRight();
        Jump();
        Attack();
    }

    public void MoveRight()//오른쪽 처리
    {
        inputRight = true;
        inputLeft = false;
    } 
    public void MoveLeft()//왼쪽 처리
    {
        if (status.isCursed == true){
            inputLeft = false;
            inputRight = false;
        }
        else{
            inputLeft = true;
            inputRight = false;
        }

    } 
    public void Jump()//점프 처리
    {
        inputJump = true;
    } 

    public void Attack()//공격 처리
    {
        if (!status.isAttacking)
        {
            status.isAttacking = true;
        }
    } 
    
    public void StopMoving()//이동 멈춤 처리
    {
        inputRight = false;
        inputLeft = false;
    }
}