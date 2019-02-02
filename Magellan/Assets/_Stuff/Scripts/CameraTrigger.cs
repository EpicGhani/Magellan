using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
	public Transform cameraTarget;
	public CameraFollow camFollow;
	public Vector3 offset;
	public Transition trans;
	public bool transition;
	public Animator anim;
	public GameObject[] objToDelete;
	public GameObject[] objToEnable;


	void OnTriggerEnter(Collider col)
	{
		if(col.tag == "Player")
		{
			Debug.Log ("Colliding with "+col.name);
			if(trans)
				StartCoroutine(TransitionScene());
			else
			{
				if(camFollow!=null)
				{
					camFollow.enabled = true;
					camFollow.target = cameraTarget;
					camFollow.offset = offset;
				}
				if(anim != null)
					anim.enabled = false;
				for (int i = 0; i < objToEnable.Length; i++)
				{
					objToEnable[i].SetActive(true);
				}
				for (int i = 0; i < objToDelete.Length; i++) 
				{
					Destroy(objToDelete[i]);
				}
			}
		}
	}
	IEnumerator TransitionScene()
	{
	
		trans.GameOver();
		yield return new WaitForSeconds(2);
		if(camFollow!=null)
		{
			camFollow.enabled = true;
			camFollow.target = cameraTarget;
			camFollow.offset = offset;
		}
		if(anim != null)
			anim.enabled = false;
		for (int i = 0; i < objToEnable.Length; i++)
		{
			objToEnable[i].SetActive(true);
		}
		for (int i = 0; i < objToDelete.Length; i++) 
		{
			Destroy(objToDelete[i]);
		}
		yield return new WaitForSeconds(2);
		trans.StartGame();
	}
}
