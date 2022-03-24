using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class DialogueManager : MonoBehaviour {

	public TMP_Text nameText;
	public TMP_Text dialogueText;
	public GameObject DialoguePanel;
	public GameObject firstDialogue;
	public GameObject secondDialogue;
	int dialogues;
	public Animator animator;

	public UnityEvent OnEndDialogue = new UnityEvent();
	public UnityEvent CharacterSpeaking = new UnityEvent();

	private Queue<string> sentences = new Queue<string>();
	private Queue<string> names = new Queue<string>();

	Logger Logger;
	public bool CanLog;
	
	// Use this for initialization
	void Start () {
		sentences = new Queue<string>();
		names = new Queue<string>();
		Logger = FindObjectOfType<Logger>();
	}
	void Update()
	{
		if (dialogues == 0)
		{
			FirstDialogue();
		}
		Logger.LogError("Login from ", this,CanLog);
	}

	public void StartDialogue (Dialogue dialogue)
	{
		animator.SetBool("IsOpen", true); 
		DialoguePanel.SetActive(true); 
		//nameText.text = dialogue.name;

		sentences.Clear();
        names.Clear();
        foreach (string sentence in dialogue.sentences)
		{
			
			sentences.Enqueue(sentence);
			
		}
        foreach (string name in dialogue.names)
        {
            names.Enqueue(name);
        }

        DisplayNextSentence();
	}

	public void DisplayNextSentence ()
	{

        //if (this.sentences.Count == 0)
        //{
        //    if (OnEndDialogue != null)
        //    {
        //        OnEndDialogue.Invoke();
        //    }
        //    return;
        //}
        if (this.names.Count == 0)
        {
            if (OnEndDialogue != null)
            {
                OnEndDialogue.Invoke();
				DialoguePanel.SetActive(false);

			}
            return;
        }

        string sentence = sentences.Dequeue();
        string name = names.Dequeue();

        StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
        StartCoroutine(TypeName(name));
    }

    IEnumerator TypeSentence (string sentence)
	{
		dialogueText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}
	IEnumerator TypeName(string name)
	{
		nameText.text = "";
		foreach (char letter in name.ToCharArray())
		{
			nameText.text += letter;
			yield return null;
		}
	}
	public void Stop()
    {
		animator.SetBool("IsOpen", false);
    }
	void FirstDialogue()
	{
		firstDialogue.GetComponent<DialogueTrigger>().TriggerDialogue();
		dialogues++;
	}


}
