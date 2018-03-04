using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogBehaviour : MonoBehaviour {

    public Text nameText;
    public Text dialogueText;

    public Queue<string> sentences;

    //public Animator anim; <--- utilizar para fazer animações com as caixas de dialogo
    //utilizar booleana isOpen na hora de ativar e desativa a animação do dialogo

	void Start () {
        sentences = new Queue<string>();
	}
	
	 
	void Update () {
		
	}

    public void StartDialog(ObjectDialog dialogue)
    {
        Debug.Log("Starting conversation with :" + dialogue.name);

        nameText.text = dialogue.name;

        sentences.Clear();

        foreach(string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialog();
            return;
        }
      string sentence =  sentences.Dequeue();
        //dialogueText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

    }

    IEnumerator  TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialog()
    {
        Debug.Log("End Conversation");
            
    }
}
