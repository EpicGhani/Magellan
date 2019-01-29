using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Animator anim;
    public CameraFollow camFollow;

	void Update ()
    {
	    if(!anim.GetCurrentAnimatorStateInfo(0).IsName("intro1"))
        {
            camFollow.enabled = true;
        }
	}
}
