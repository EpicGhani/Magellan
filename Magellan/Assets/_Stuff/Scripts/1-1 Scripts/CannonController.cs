using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonController : MonoBehaviour 
{
	public float delay;
	public ParticleSystem particle;

	float timer;
	AudioSource source;

	void Start()
	{
		source = GetComponent<AudioSource>();
		delay = Random.Range(2,5);
	}
	void Update()
	{

		timer += Time.deltaTime;

		if(timer > delay)
			Fire ();
	}

	void Fire()
	{
		StartCoroutine(FireCannon());
		delay = Random.Range(2,5);
		timer = 0;
	}
	IEnumerator FireCannon()
	{
		source.Play();
		yield return new WaitForSeconds(.3f);
		particle.Emit(5);
		yield return new WaitForSeconds(5);
		source.Stop();
	}
}
