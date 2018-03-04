using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class closingDoor : MonoBehaviour {

	public GameObject door;
	Animator anim;
	// Use this for initialization
	void Start () {
		anim = door.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	void OnTriggerEnter(){



			anim.SetTrigger ("IsClosed");

	}
}
