using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ProgressScript : MonoBehaviour 
{
	public int SceneIndex;
	void Start ()
	{
		PlayerPrefs.SetInt("Progress",SceneIndex);
	}
}
