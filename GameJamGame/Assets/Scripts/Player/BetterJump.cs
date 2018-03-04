using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class BetterJump : MonoBehaviour {

	public float fallMultiplier = 2.5f;
	public float lowMultiplier = 2f;

	Rigidbody rb;
	 
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
 
	void Update () {

		if (rb.velocity.y < 0) {

			rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
		
		} else if (rb.velocity.y > 0 && Input.GetButton ("Jump")) {
		
			rb.velocity += Vector3.up * Physics.gravity.y * (lowMultiplier - 1) * Time.deltaTime;

		}

	}
}
