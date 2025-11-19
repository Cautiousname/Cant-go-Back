// ============================================
// [ChangeScene.cs]
// Role : 씬 관리 Load, 카메라 전환
// Input : 
// Output : 
// -LoadScene랑 짝궁
// ============================================

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Cinemachine;
public class ChangeScene : MonoBehaviour
{
    public CinemachineVirtualCamera targetCamera;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0)){
            UnityEngine.SceneManagement.SceneManager.LoadScene("IntroUI");
        }
        else if (Input.GetKeyDown(KeyCode.Keypad1)){
            UnityEngine.SceneManagement.SceneManager.LoadScene("Stage1");
        }
        else if (Input.GetKeyDown(KeyCode.Keypad2)){
            UnityEngine.SceneManagement.SceneManager.LoadScene("Stage2");
        }
        else if (Input.GetKeyDown(KeyCode.Keypad3)){
            UnityEngine.SceneManagement.SceneManager.LoadScene("Stage3");
        }
        else if (Input.GetKeyDown(KeyCode.Keypad4)){
            UnityEngine.SceneManagement.SceneManager.LoadScene("Stage4");
        }
        else if (Input.GetKeyDown(KeyCode.Keypad5)){
            UnityEngine.SceneManagement.SceneManager.LoadScene("Stage5");
        }
        else if (Input.GetKeyDown(KeyCode.Keypad9)){
            UnityEngine.SceneManagement.SceneManager.LoadScene("Outtro");
        }
    }    void UnActivateCamera()
    {
        targetCamera.Priority = 15; // 다른 카메라보다 낮은 우선순위 설정
    }
}
