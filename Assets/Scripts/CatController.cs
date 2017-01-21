using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
	public WaveController WavePrefab;

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{
		if (InputController.IsConditionMet (CommandType.LowRoar))
		{
			Debug.Log ("ROAR");
			ShowWave (CommandType.LowRoar);
		}
		else if (InputController.IsConditionMet (CommandType.Screech))
		{
			Debug.Log ("SCREEEECH");
			ShowWave (CommandType.Screech);
		}
		else if (InputController.IsConditionMet (CommandType.Hiss))
		{
			Debug.Log ("HISSSSSSSS");
			ShowWave (CommandType.Hiss);
		}
		else
		{
			WavePrefab.gameObject.SetActive (false);
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Obstacle")
		{
			Destroy(collision.gameObject);
		}
	}

	void ShowWave(CommandType type)
	{
		WavePrefab.waveType = type;
		WavePrefab.gameObject.SetActive (true);
	}
}
