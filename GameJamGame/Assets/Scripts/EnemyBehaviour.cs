using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour {

	public float attackTimeDelay = 0.5f;
	LifePlayerBehaviour life;



	private Transform playerMov;
	private float time;
	private GameObject player;
	private int damage = 20;
	private bool playerSurrounded;

	//enemyMovement




	Rigidbody rb;


	// Use this for initialization
	void Start () {


		player = GameObject.FindGameObjectWithTag ("Player");

		life = player.GetComponent<LifePlayerBehaviour> ();

			

	}
	
	// Update is called once per frame
	void Update () {


		time += Time.deltaTime;
		if(time >= attackTimeDelay && playerSurrounded ){
			Attack ();
		}



	}


	void OnTriggerEnter(Collider obj){

		if (obj.gameObject == player) {

			playerSurrounded = true;

		}

	}

	void OnTriggerExit(Collider obj){

		if (obj.gameObject == player) {

			playerSurrounded = false;

		}

	}

	void Attack(){

		time = 0f;
		if (LifePlayerBehaviour.actualLife > 0) {
			life.HasDamage (damage);
		}

	}



}
