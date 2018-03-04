using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class throwedItemController : MonoBehaviour {

	public GameObject item;

	public Transform spawnPoint;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
			
	}

	public void Throw(){

		Instantiate (item, spawnPoint.position , spawnPoint.rotation);
	
	}
}
