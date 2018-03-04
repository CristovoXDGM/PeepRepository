using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBehaviour : MonoBehaviour {


	//private GameObject player;
	public GameObject door;
	Animator anim;
	public AudioClip KeySound;

	private bool keyEnabl =true;
 
	void Start () {

		//player = GameObject.FindGameObjectWithTag ("Player");

		anim = door.GetComponent<Animator> ();
	}
	
	 
	void Update () {

		transform.Rotate (0f, 1f, 0);

		if (!keyEnabl) {

			anim.SetTrigger ("isOpen");

		}

	}

	void OnTriggerEnter(Collider col){

			
		GetComponent<AudioSource> ().PlayOneShot (KeySound);
			GetComponent<Renderer> ().enabled= false;
			GetComponent<Collider> ().enabled= false;

			Destroy (gameObject, 2.0f);
			keyEnabl = false;

	

	}
}
