using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class QuestionManager : MonoBehaviour 
{
	public TextMeshProUGUI name;
	public TextMeshProUGUI question;
	public int requiredPoints = 3;
	public ChangeScene cs;
	public ChoicesButton[] button;
	public Questions[] questions;
	int points = 0;

	int[] randomPosition = new int[]{0,1,2,3};
	int rand;
	void Start()
	{
		GenerateQuestion();	
	}
	public void GenerateQuestion()
	{
		name.SetText("");
		question.SetText("");

		rand = Random.Range(0,questions.Length);

		name.SetText("Question");
		question.SetText(questions[rand].question);
		for (int i = 0; i < randomPosition.Length; i++)
		{
			int index = (int)Random.value*randomPosition.Length;

			int temp = randomPosition[i];
			randomPosition[i] = randomPosition[index];
			randomPosition[index] = temp;
		}
		for (int i = 0; i < button.Length; i++)
		{
			if(randomPosition[i] == 0)
				button[i].answer = questions[rand].correctAnswer;
			else if(i == 3)
				button[i].answer = questions[rand].choices[0];
			else
				button[i].answer = questions[rand].choices[i];
			button[i].addedListener = false;
		}
	}

	public void CheckAnswer(string answer)
	{
		if(points < requiredPoints)
		{
			if(answer.Equals(questions[rand].correctAnswer))
			{
				points++;
				GenerateQuestion();
				Debug.Log ("Correct");
			}else
			{
				GenerateQuestion();
				Debug.Log ("Wrong!");
				//decrease life;
			}
			return;
		}
		else if(points == requiredPoints)
		{
			cs.enabled = true;
			this.gameObject.SetActive(false);
		}
	}
}
[System.Serializable]
public struct Questions
{
	[TextAreaAttribute(3,5)]
	public string question;
	public string[] choices;
	public string correctAnswer;
}
