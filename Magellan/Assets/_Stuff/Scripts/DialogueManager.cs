using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour 
{
	public TextMeshProUGUI name;
	public TextMeshProUGUI body;
	public Dialogues[] dialogueSet;
	public int statementIndex;
	[Header("SCRIPTS MUST BE IN ORDER")]
	public ChangeScene[] changeSceneScripts;

	int indexToLoad;
	public int sceneChangeIndex;
	bool doneLoading;

	void OnEnable()
	{
		StartCoroutine(LoadDialogue());
	}

	public void StartDialogue()
	{
		Debug.Log ("Clicked");
		if(doneLoading)
		{
			StartCoroutine(LoadDialogue());
			doneLoading = false;
		}
	}

	IEnumerator LoadDialogue()
	{
		if(dialogueSet[statementIndex].dialogues.Length>indexToLoad)
		{		
			body.SetText("");
			name.SetText(dialogueSet[statementIndex].dialogues[indexToLoad].name);
			yield return new WaitForSeconds(0.5f);
			body.SetText(dialogueSet[statementIndex].dialogues[indexToLoad].body);
			indexToLoad++;
		}
		else
		{
			indexToLoad = 0;
			name.SetText("");
			body.SetText("");
			this.gameObject.SetActive(false);
			if(dialogueSet[statementIndex].dialogues[indexToLoad].Type == DialogueSets.DialogueType.Dialogue)
			{
				changeSceneScripts[sceneChangeIndex].enabled = true;
				sceneChangeIndex++;
			}
			statementIndex++;
		}
		doneLoading = true;
	}
}

[System.Serializable]
public struct Dialogues
{
	public DialogueSets[] dialogues;
}
[System.Serializable]
public struct DialogueSets
{
	public enum DialogueType{Narration,Dialogue}
	public DialogueType Type;
	public string name;
	[TextAreaAttribute(3,5)]
	public string body;
}
