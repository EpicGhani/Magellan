using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatAnimMovement : MonoBehaviour 
{
	public Transform waypoint;
	public float speed;

	void Update()
	{
		if(Vector3.Distance(transform.position,waypoint.position) >= 0.2f)
		{
			Vector3 dir = waypoint.position - transform.position;
			transform.LookAt(new Vector3(waypoint.position.x,transform.position.y,waypoint.position.z));
			transform.Translate(dir.normalized * speed * Time.deltaTime, Space.World);
		}else 
			this.enabled = false;
	}
}
