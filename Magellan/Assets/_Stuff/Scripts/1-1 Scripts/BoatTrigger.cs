using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatTrigger : MonoBehaviour 
{
	public Transition transition;
	public Transform cameraTarget;
	public HumanWalk human;
	public CameraFollow camFollow;
	public BoatController controller;
	public ChangeScene cs;

	void OnTriggerEnter(Collider col)
	{
		if(col.tag == "Player")
		{
			transition.GameOver();
			StartCoroutine(ChangeTarget());
			controller.enabled = false;
		}
	}

	IEnumerator ChangeTarget()
	{
		yield return new WaitForSeconds(2f);
		camFollow.offset = new Vector3(0,1,-2);
		camFollow.target = cameraTarget;
		yield return new WaitForSeconds(2f);
		cs.enabled = true;
		transition.StartGame();
		human.enabled = true;
	}
}
