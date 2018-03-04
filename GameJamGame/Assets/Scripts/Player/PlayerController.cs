using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {


	public float speed = 5.0f;
	public float verticalVelocity;
	private float gravity = 1.0f;

	public throwedItemController item;
	private bool secondJumpAvail=false;
	private bool facingRight;
	private float Inputdirection;
	private Animator anim;

	private Vector3 moveMent;
	private CharacterController controller;


	public AudioClip Jumpsound;









	void Awake () {

		anim = GetComponent<Animator> ();
		controller = GetComponent<CharacterController> ();
		item = GetComponentInChildren<throwedItemController> ();
//		rb = GetComponent<Rigidbody> ();
		facingRight = true;
	

	}
	

	void Update () {

		Inputdirection =  Input.GetAxis("Horizontal") * speed;//CrossPlatformInput
		Move (Inputdirection);
		Animation (Inputdirection);

		if (controller.isGrounded) {
			verticalVelocity = 0;
			if ( Input.GetKeyDown(KeyCode.Space)  ) { // CrossPlatformInputManager
				
				GetComponent<AudioSource> ().PlayOneShot (Jumpsound);
				verticalVelocity = 5;
				anim.SetTrigger ("isJumping");
				secondJumpAvail = true;
			}
		} 
		else {
			if ( Input.GetButtonDown ("Jump")  ) { // CrossPlatformInputManager

				if (secondJumpAvail) {
					
					GetComponent<AudioSource> ().PlayOneShot (Jumpsound);
					verticalVelocity = 5;
					anim.SetTrigger ("isJumping");
					secondJumpAvail = false;
				}

			}
			verticalVelocity -= gravity;

		}
			

		//Input.GetAxis("Horizontal");

		if (Input.GetKey (KeyCode.M)) {
			
			item.Throw ();
		}

	}



	void Move(float x){

		moveMent = new Vector3 (x, verticalVelocity, 0f);
		controller.Move(moveMent * Time.deltaTime);

		if (x > 0 && !facingRight) {
			flip ();
		} else if (x < 0 && facingRight) {
			flip ();
		
		}

	}

	void flip(){

		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.z *= -1;
		transform.localScale = theScale;

	}


	void Animation(float x){
		if(x !=0 ){
		anim.SetBool ("isMoving", true);
			anim.SetBool ("isIdle", false);
	}else{
		anim.SetBool ("isMoving", false);
			anim.SetBool ("isIdle", true);
	}

 }

}