using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraTrigger : MonoBehaviour
{
	public Transform cameraTarget;
	public CameraFollow camFollow;
	public Vector3 offset;

	void OnTriggerEnter(Collider col)
	{
		if(col.tag == "Player")
		{
			camFollow.target = cameraTarget;
			camFollow.offset = offset;
		}
	}
}
