using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour 
{
	public Transform target;
	public Vector3 offset;
	public float followSpeed = 10;
	public float lookspeed = 10;
	
	
	public void LookAtTarget()
	{
		Vector3 dir = target.position - transform.position;
		Quaternion rot = Quaternion.LookRotation(dir, Vector3.up);
		transform.rotation = Quaternion.Lerp (transform.rotation, rot,lookspeed * Time.deltaTime);
	}
	public void MoveToTarget()
	{
		Vector3 targetPos = target.position + 
			target.forward * offset.z +
				target.right * offset.x +
				target.up * offset.y;
		transform.position = Vector3.Lerp(transform.position, targetPos, followSpeed * Time.deltaTime);
	}
	private void FixedUpdate()
	{
		LookAtTarget();
		MoveToTarget();
	}
}
