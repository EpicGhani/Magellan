using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeScene : MonoBehaviour
{
	public float delay;
	public GameObject[] targetToEnable;
	public GameObject[] targetToDisable;
	public Transition transition;
	public AudioSource targetAudio;
	public AudioSource thisAudio;

	float timer;

	void Update()
	{
		if(timer <= delay)
			timer += Time.deltaTime;
		else
		{
			StartCoroutine(Change());
			timer = 0;
		}
	}

	IEnumerator Change()
	{
		transition.GameOver();
		while(thisAudio.volume >0)
		{
			thisAudio.volume-=Time.deltaTime/transition.fadeSpeed;
			yield return null;
		}
		yield return new WaitForSeconds(2);
		for (int i = 0; i < targetToEnable.Length; i++)
		{
			targetToEnable[i].SetActive(true);
		}
		transition.StartGame();
		while(targetAudio.volume <1)
		{
			targetAudio.volume+=Time.deltaTime/transition.fadeSpeed;
			yield return null;
		}
		for (int i = 0; i < targetToDisable.Length; i++)
		{
			targetToDisable[i].SetActive(false);
		}
	}
}
