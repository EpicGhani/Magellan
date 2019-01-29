using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class HumanWalk : MonoBehaviour
{
    public enum MoveState {Loop,Once,Random}
    public MoveState moveType;
    public float walkSpeed;
    public float lookSpeed;
    public Transform[] waypoints;
	public AnimationClip[] animClip;


    CharacterController cc;
	Animation animation;
    Transform target;
    int currWayPoint;

	  // Use this for initialization
	void Start ()
  	{
    	cc = GetComponent<CharacterController>();
		animation = GetComponent<Animation>();
	}

    // Update is called once per frame
    void Update()
    {
		if(cc.velocity == Vector3.zero)
		{
			animation.clip = animClip[0];
			animation.Play();
		}
		else if (cc.velocity != Vector3.zero)
		{
			animation.clip = animClip[1];
			animation.Play();
		}


        if (moveType == MoveState.Once)
        {
            target = waypoints[currWayPoint];
			if(Vector3.Distance(transform.position, waypoints[waypoints.Length-1].position) == .1f)
			{
				animation.clip = animClip[0];
				animation.Play();
			}
            if (Vector3.Distance(transform.position, target.position) >= .1f)
            {
                Vector3 tar = new Vector3(target.position.x, transform.position.y, target.position.z);

                var rot = Quaternion.LookRotation(tar - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * lookSpeed);

                Vector3 moveDir = tar - transform.position;
                if (moveDir.magnitude > 1)
                {
                    cc.Move(moveDir.normalized * walkSpeed * Time.deltaTime);
                }
                else
                {
                    if (currWayPoint < waypoints.Length-1)
                        currWayPoint++;
					else
					{
						animation.clip = animClip[0];
						animation.Play ();
					}
                }
            }
        }
        else if (moveType == MoveState.Loop)
        {
            target = waypoints[currWayPoint];
            if (Vector3.Distance(transform.position, target.position) >= .1f)
            {
                Vector3 tar = new Vector3(target.position.x, transform.position.y, target.position.z);

                var rot = Quaternion.LookRotation(tar - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * lookSpeed);

                Vector3 moveDir = tar - transform.position;
                if (moveDir.magnitude > 1)
                {
                    cc.Move(moveDir.normalized * walkSpeed * Time.deltaTime);
                }
                else
                {
                    if (currWayPoint < waypoints.Length - 1)
                        currWayPoint++;
                    else if (currWayPoint == waypoints.Length - 1)
                        currWayPoint = 0;
                }
            }
        }
        else if (moveType == MoveState.Random)
        {
            target = waypoints[currWayPoint];
            if (Vector3.Distance(transform.position, target.position) >= .1f)
            {
                Vector3 tar = new Vector3(target.position.x, transform.position.y, target.position.z);

                var rot = Quaternion.LookRotation(tar - transform.position);
                transform.rotation = Quaternion.Slerp(transform.rotation, rot, Time.deltaTime * lookSpeed);

                Vector3 moveDir = tar - transform.position;
                if (moveDir.magnitude > 1)
                {
                    cc.Move(moveDir.normalized * walkSpeed * Time.deltaTime);
                }
                else
                {
                    currWayPoint = Random.Range(0, waypoints.Length);
                }
            }
        }
    }
}
