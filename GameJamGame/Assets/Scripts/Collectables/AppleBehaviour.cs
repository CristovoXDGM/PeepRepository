using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AppleBehaviour : MonoBehaviour {

	private GameObject player;
    
	public Text scoreT;
	private bool isVisible = true;
	public AudioClip ColectSound;
    LifePlayerBehaviour lifee;

    public static int score;
    [HideInInspector]
    public int aux_score;
	// Use this for initialization
	void Awake () {
        score = 0;

        scoreT.text = "Score: " + score.ToString();

	}
	
	

	void OnTriggerEnter(){
			
		    GetComponent<AudioSource> ().PlayOneShot (ColectSound);
		    GetComponent<MeshRenderer> ().enabled = false;
		    GetComponent<Collider> ().enabled = false;
			Destroy (gameObject, 3.0f);
		    isVisible = false;
		if (isVisible == false  ) {
			score += 20;
			scoreT.text = "Score: " + score.ToString();
            LifePlayerBehaviour.actualLife += 20;

        }

        if(score == 100) {
            LifePlayerBehaviour.lifeCounter += 1;
        }

        
	}

    

}
