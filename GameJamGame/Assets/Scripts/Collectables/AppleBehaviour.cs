using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AppleBehaviour : MonoBehaviour {

	private GameObject player;
    
	public Text text;
	private bool isVisible = true;
	public AudioClip ColectSound;
    
    public static int score;
	// Use this for initialization
	void Awake () {
        
		text.text = "Score: " + score.ToString();

	}
	
	// Update is called once per frame
	void Update () {

       

	}

	void OnTriggerEnter(){
			
		    GetComponent<AudioSource> ().PlayOneShot (ColectSound);
		    GetComponent<MeshRenderer> ().enabled = false;
		    GetComponent<Collider> ().enabled = false;
			Destroy (gameObject, 3.0f);
		    isVisible = false;
		if (isVisible == false  ) {
			score += 20;
			text.text = "Score: " + score.ToString();
		}
	}

    

}
