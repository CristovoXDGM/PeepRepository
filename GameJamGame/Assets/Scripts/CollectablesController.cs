using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesController : MonoBehaviour {


	public AudioClip colectSound;

	//public int passedValue = 5;



	// Use this for initialization
	void Start () {

	

	}
	
	// Update is called once per frame
	void Update () {

		transform.Rotate (0,1,0);
		
	}

	void OnTriggerEnter(Collider other){
			

			GetComponent<AudioSource> ().PlayOneShot(colectSound);
			GetComponent<Renderer> ().enabled= false;
		GetComponent<Collider> ().enabled= false;

		Destroy (gameObject, 2.0f);

	}
}
