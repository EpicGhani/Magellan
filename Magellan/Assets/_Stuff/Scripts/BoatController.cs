using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatController : MonoBehaviour
{
    public float speed;
    public Animator anim;

	void Update ()
    {
        if(!anim.GetCurrentAnimatorStateInfo(0).IsName("intro1"))
        {
            if(Input.GetKeyDown(KeyCode.W))
            {
                transform.Translate(Vector3.forward.normalized * speed * Time.deltaTime, Space.World);
            }
            Debug.Log("Animation Done!");
        }
	}
}
