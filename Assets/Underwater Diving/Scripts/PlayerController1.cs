// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class PlayerController1 : MonoBehaviour{

// 	public float moveSpeedValue = 5f;
// 	//public bool rushing = false;
// 	private float speedMod = 0;

// 	float timeLeft = 2f;

// 	private Rigidbody2D myRigidBody;
// 	private Animator myAnim;
// 	public GameObject bubbles;
// 	public PlayerStatus playerStatus;

// 	// Use this for initialization
// 	void Start (){
// 		myRigidBody = GetComponent<Rigidbody2D> ();	
// 		myAnim = GetComponent<Animator> ();
// 	}
	
// 	// Update is called once per frame
// 	void Update (){
// 		movePlayer ();

// 	}

// 	void OceanInMove (){//오션에서 다른 무빙
// 		if (Input.GetAxisRaw ("Horizontal") > 0f) {
// 			transform.localScale = new Vector3(1f,1f,1f);//오른쪽 바라보기
// 			movePlayer ();
// 		} else if (Input.GetAxisRaw ("Horizontal") < 0f) {			
// 			transform.localScale = new Vector3(-1f,1f,1f);//왼쪽 바라보기
// 			movePlayer ();
// 		} else if (Input.GetAxisRaw ("Vertical") > 0f) {
// 			myRigidBody.velocity = new Vector3 (myRigidBody.velocity.x, moveSpeedValue, 0f);//위로 이동
// 		} else if (Input.GetAxis ("Vertical") < 0f) {
// 			myRigidBody.velocity = new Vector3 (myRigidBody.velocity.x, -moveSpeedValue, 0f);//아래로 이동
// 		}

// 		if (Input.GetButtonDown("Jump") && playerStatus != null) {
// 			//점프처리
			
// 		}	
// 	}

// 	void movePlayer(){//플레이어 이동
// 		if (transform.localScale.x == 1)
// 		{//오른쪽 이동
// 			myRigidBody.velocity = new Vector3(moveSpeedValue + speedMod, myRigidBody.velocity.y, 0f);
// 		}
// 		else
// 		{
// 			if (playerStatus.isCursed == true) {
// 				myRigidBody.velocity = Vector3.zero;//이동 불가
// 			} else {
// 				myRigidBody.velocity = new Vector3(-(moveSpeedValue + speedMod), myRigidBody.velocity.y, 0f);//왼쪽 이동
// 			}
			
// 		}	
// 	}

// 	public void hurt(){//피격 애니메이션 재생 animation으로 옮기기
// 		myAnim.SetTrigger ("hurt");
// 	}

// }

