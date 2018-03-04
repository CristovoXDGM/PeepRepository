using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogTrigger : MonoBehaviour {

    public ObjectDialog dialogue;

    public void TriggerDialog()
    {
        FindObjectOfType<DialogBehaviour>().StartDialog(dialogue);
    }

}
