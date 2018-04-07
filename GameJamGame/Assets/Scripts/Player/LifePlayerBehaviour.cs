 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LifePlayerBehaviour : MonoBehaviour {

    AppleBehaviour score;

    public static int lifeCounter = 3;
    public int startLife = 100;
	public static int actualLife;
    
    public Text lifeCount;
    public Slider lifeSlider;
	public Image damageImage;


	public float flashVelo = 5f;
	public Color flashColor = new Color(1f,0f,0f,0.1f);
	public AudioClip hurtSound;

    [HideInInspector]
   
	private Animator anim;
	//private AudioSource playerAudio;
	BehaviourMovement playerMovement;
	private bool isDead;
	private bool hadDamage;


	void Awake(){
       
        lifeCount.text = lifeCounter.ToString();
        anim = GetComponent<Animator> ();
		playerMovement = GetComponent<BehaviourMovement> ();
		actualLife = startLife;

	}

     void Update() {

        lifeSlider.value = actualLife;
        lifeCount.text = lifeCounter.ToString();
        if (actualLife > 100) {
            actualLife = 100;
        }
       
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

        lifeCounter--;
        lifeCount.text = lifeCounter.ToString();

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
