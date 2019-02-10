using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public Animator anim;
	public CameraFollow camFollow;
	public Transition Instruction;

	bool starFollow = false;
	void Update ()
	{
		if(!starFollow)
		{
			if(anim.GetCurrentAnimatorStateInfo(0).IsName("intro1") &&
			   anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
			{
				anim.enabled = false;
				starFollow = true;
				Instruction.GameOver();
			}
		}
		else camFollow.enabled = true;
	}
}
