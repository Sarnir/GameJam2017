using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MexicanDogWaveController : Obstacle
{
	public GameObject Dog;
	public int DogCount;
	DateTime TimeSpawned;
	int DogsSpawned;

	void Start()
	{
		TimeSpawned = DateTime.Now;
		DogsSpawned = 0;
	}

	void Update()
	{
		if (DateTime.Now - TimeSpawned >= TimeSpan.FromSeconds(0.5))
		{
			if (DogsSpawned < DogCount)
			{
				Instantiate(Dog);
				TimeSpawned = DateTime.Now;
				DogsSpawned++;
			}
			else
			{
				Destroy(gameObject);
			}
		}
	}
}
