using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {
	
	public void Jogar(){
	
		SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex+1);
	
	}
	public void Sair(){
		Application.Quit();
	}
	public void VoltarMenu(){

		SceneManager.LoadScene (0);

	}
}
