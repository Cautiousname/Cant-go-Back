//=============================================================
// [InputManager.cs]
// Role    : 플레이어 입력 처리
// Input   : Unity Input System
// Output  : PlayerController (입력 전달)
// Jump: Space, Move: Left/Right Arrow, Attack: Z
//=============================================================

using Unity.VisualScripting;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InputManager : MonoBehaviour
{
    // 플레이어 입력 처리
    private PlayerController playerController;

    private void Awake()
    {
        playerController = GetComponent<PlayerController>();
    }

    private void Update()
    {
        // 입력 처리 로직
        if (Input.GetKeyDown(KeyCode.Z))
        {
            playerController.Attack();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerController.Jump();
        }

        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerController.MoveLeft();
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            playerController.MoveRight();
        }
        else
        {
            playerController.StopMoving();
        }

        
    }
}
