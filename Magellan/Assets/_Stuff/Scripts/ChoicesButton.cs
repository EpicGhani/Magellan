using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class ChoicesButton : MonoBehaviour 
{
	public string answer;
	public TextMeshProUGUI answerTxt;
	public QuestionManager manager;

	Button thisButton;
	[HideInInspector]
	public bool addedListener = false;

	void Start()
	{
		thisButton = GetComponent<Button>();
	}
	void Update()
	{
		answerTxt.SetText(answer);
		if(!addedListener)
		{
			thisButton.onClick.AddListener(delegate {manager.CheckAnswer(answer);});
			addedListener = true;
		}
	}
}
