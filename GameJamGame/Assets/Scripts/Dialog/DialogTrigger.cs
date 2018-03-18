using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour {
    public GameObject alertboard;
    public GameObject collidergameObject;
    public ObjectDialog dialogue;
    public static bool DialogStarted = false;

    public void TriggerDialog()
    {
        
    }
    void OnTriggerEnter()
    {
        Time.timeScale = 0f;
        DialogStarted = true;
        alertboard.SetActive(true);
        FindObjectOfType<DialogBehaviour>().StartDialog(dialogue);

    }
    public void Continue()
    {
        collidergameObject.GetComponent<BoxCollider>().enabled = false;
        Time.timeScale = 1f;
        DialogStarted = false;
        alertboard.SetActive(false);
        
    }




}
