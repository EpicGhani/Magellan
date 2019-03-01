using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour 
{
	public Button loadButton;
	public Transition trans;

	void Start()
	{
		if(PlayerPrefs.GetInt("Progress") == 0 || PlayerPrefs.GetInt("Progress") == null)
			loadButton.interactable = false;
		else
			loadButton.interactable = true;
	}

	public void StartGame()
	{
		trans.targetScene = 1;
		trans.GameOver();
	}
	public void LoadGame()
	{
		trans.targetScene=PlayerPrefs.GetInt("Progress");
		trans.GameOver();
	}
	public void QuitGame()
	{
		Application.Quit();
	}
}
