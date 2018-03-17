 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifePlayerBehaviour : MonoBehaviour {


	public int startLife = 100;
	public int actualLife;
	public Slider lifeSlider;
	public Image damageImage;

	public float flashVelo = 5f;
	public Color flashColor = new Color(1f,0f,0f,0.1f);
	public AudioClip hurtSound;

	private Animator anim;
	//private AudioSource playerAudio;
	BehaviourMovement playerMovement;
	private bool isDead;
	private bool hadDamage;


	void Awake(){

		anim = GetComponent<Animator> ();
		playerMovement = GetComponent<BehaviourMovement> ();
		actualLife = startLife;

	}


	
	// Update is called once per frame
	void Update () {




	}

	public void HasDamage(int life){
	
		hadDamage = true;
		actualLife -= life;
		lifeSlider.value = actualLife;

		GetComponent<AudioSource> ().PlayOneShot (hurtSound);

		if (actualLife <= 0 && !isDead) {
		
			Die();
			TimeTorestar ();
		}

	}

	void Die(){
		

		isDead = true;
		anim.SetTrigger ("isDead");

		playerMovement.enabled = false;
       
        

	}

	public void TimeTorestar(){

		StartCoroutine (RestartLevel ());

	}

	IEnumerator RestartLevel(){
		yield return new WaitForSeconds (4);
		SceneManager.LoadScene (2);

	}
}
