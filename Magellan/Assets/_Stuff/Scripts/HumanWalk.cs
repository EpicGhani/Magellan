using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class HumanWalk : MonoBehaviour
{
	public float speed;
	public float rotDamping;
	public bool randomize;
	public Transform[] waypoints;

	CharacterController cc;
	Transform target;

	// Use this for initialization
	void Start () {
		cc = GetComponent<CharacterController> ();
	}
	
	// Update is called once per frame
	void Update () 
	{



		Vector3 tar = new Vector3 (target.position.x, transform.position.y, target.position.z);

		var rot = Quaternion.LookRotation(tar - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rot, Time.deltaTime * rotDamping);
	}
}
