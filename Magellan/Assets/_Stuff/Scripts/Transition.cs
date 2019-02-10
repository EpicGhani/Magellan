using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour 
{
	public enum TransType {FadeIn,FadeOut,Both};
	
	public bool goTrans = true;
	public bool selfDestruct = false;
	public bool animate = false;
	
	[Header("Main Settings")]
	public TransType type;
	public CanvasGroup targetCan;
	public float fadeSpeed = 2;
	public float waitTime = 0;
	
	[Header("Scene Change Settings")]
	public int targetScene;
	public bool changeScene = false;
	
	[Header("Animation Settings")]
	public Animator animator;
	public string animatorBool;
	public float animWaitTime = 0;
	
	void Start()
	{
		targetCan = targetCan.GetComponent<CanvasGroup>();
		if(goTrans)
		{
			if(type == TransType.FadeIn)
				StartCoroutine(FadeIn());
			else if(type == TransType.FadeOut)
				StartCoroutine(FadeOut());
			else if(type == TransType.Both)
				StartCoroutine(Both());
		}
	}
	
	void Update()
	{
		if(targetCan.alpha <= 0)
			targetCan.interactable = false;
		else if(targetCan.alpha > 0)
			targetCan.interactable = true;
	}
	
	public void StartGame()
	{
		StartCoroutine(FadeOut());
	}
	public void GameOver()
	{
		StartCoroutine(FadeIn());
	}
	
	IEnumerator FadeIn()
	{
		yield return new WaitForSeconds(waitTime);	
		while(targetCan.alpha < 0.95f)
		{
			Mathf.Clamp(targetCan.alpha,0,1);
			targetCan.alpha += Time.deltaTime / fadeSpeed;
			
			yield return null;
		}
		targetCan.alpha = 1;
		targetCan.interactable = true;
		yield return new WaitForSeconds(animWaitTime);
		if(animate)
		{
			animator.SetBool(animatorBool, true);
			animator.speed = .5f;
		}
		if(selfDestruct)
			Destroy(gameObject);
		if(changeScene)
			SceneManager.LoadScene(targetScene);
		yield return null;
	}
	IEnumerator FadeOut()
	{
		yield return new WaitForSeconds(waitTime);
		while(targetCan.alpha > 0)
		{
			Mathf.Clamp(targetCan.alpha,0,1);
			targetCan.alpha -= Time.deltaTime / fadeSpeed;
			
			yield return null;
		}
		if(changeScene)
			SceneManager.LoadScene(targetScene);
		if(selfDestruct)
			Destroy(gameObject);
		yield break;
	}
	IEnumerator Both()
	{
		yield return new WaitForSeconds(waitTime);
		while(targetCan.alpha < 0.95f)
		{
			Mathf.Clamp(targetCan.alpha,0,1);
			targetCan.alpha += Time.deltaTime / fadeSpeed;
			
			yield return null;
		}
		targetCan.alpha = 1;
		yield return new WaitForSeconds(2);
		while(targetCan.alpha > 0)
		{
			Mathf.Clamp(targetCan.alpha,0,1);
			targetCan.alpha -= Time.deltaTime / fadeSpeed;
			
			yield return null;
		}
		if(changeScene)
			SceneManager.LoadScene(targetScene);
		if(selfDestruct)
			Destroy(gameObject);
		yield break;
	}
}
