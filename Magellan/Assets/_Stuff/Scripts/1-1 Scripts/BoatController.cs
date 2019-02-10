using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour 
{
	public Animator anim;
	public float speed;
	public Transition instructions;

	bool enableMove = false;
	void Update()
	{
		if(!enableMove)
		{
			if(anim.GetCurrentAnimatorStateInfo(0).IsName("intro1") && 
			   anim.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1f)
			{
				enableMove = true;
			}
		}else
		{
			if(Input.GetKey(KeyCode.W))
			{
				transform.Translate(Vector3.forward * speed * Time.deltaTime);
				instructions.StartGame();
			}
		}
	}
}
