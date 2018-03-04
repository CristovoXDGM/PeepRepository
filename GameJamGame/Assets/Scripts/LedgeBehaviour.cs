using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LedgeBehaviour : MonoBehaviour {


	public GameObject ledge;


	void OncCollisionEnter(Collision col){
		
		foreach(ContactPoint contact in col.contacts){
			
		}

		col.transform.parent = ledge.transform;
	
	}
	void OncCollisionExit(Collision col){

		col.transform.parent = null;
	
	}

}
