using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
	// HOOKS FOR WAVES

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Alpha1))
		{
			// render high pitch wave
			throw new Exception("Glass breaker");
		}
		if (Input.GetKeyDown(KeyCode.Alpha2))
		{
			// render medium pitch wave
			throw new Exception("DEMEXICANIZER");
		}
		if (Input.GetKeyDown(KeyCode.Alpha3))
		{
			// render high pitch wave
			throw new Exception("Wall destroyer");
		}
		if (Input.GetKeyDown(KeyCode.Alpha4))
		{
			// render high pitch wave
			throw new Exception("OGÓREK PSIK");
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Obstacle")
		{
			Destroy(collision.gameObject);
		}
	}
}
