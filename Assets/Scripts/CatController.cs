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
		if (InputController.IsConditionMet (CommandType.LowRoar))
			Debug.Log ("ROAR");
		else if (InputController.IsConditionMet (CommandType.Screech))
			Debug.Log ("SCREEEECH");
		else if (InputController.IsConditionMet (CommandType.Hiss))
			Debug.Log ("HISSSSSSSS");
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Obstacle")
		{
			Destroy(collision.gameObject);
		}
	}
}
