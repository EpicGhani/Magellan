﻿using System.Collections;
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
	bool changed = false;

	void Update()
	{
		if(!changed)
		{
			if(timer <= delay)
				timer += Time.deltaTime;
			else
			{
				StartCoroutine(Change());
				timer = 0;
			}
		}
	}

	IEnumerator Change()
	{
		if(transition!=null)
		transition.GameOver();
		if(thisAudio != null)
		{
			while(thisAudio.volume >0)
			{
				thisAudio.volume-=Time.deltaTime/2;
				yield return null;
			}
		}
		yield return new WaitForSeconds(2);
		for (int i = 0; i < targetToEnable.Length; i++)
		{
			targetToEnable[i].SetActive(true);
		}
		if(transition!=null)
		transition.StartGame();
		if(targetAudio != null)
		{
			while(targetAudio.volume <1)
			{
				targetAudio.volume+=Time.deltaTime/2;
				yield return null;
			}
		}
		for (int i = 0; i < targetToDisable.Length; i++)
		{
			targetToDisable[i].SetActive(false);
		}
		changed = true;
	}
}
