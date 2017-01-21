using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MexicanDogWaveController : Obstacle
{
	public DogController Dog;
	public int DogCount;
	DateTime TimeSpawned;
	int DogsSpawned;

	Transform parent;
	Vector3 spawnPos;
	bool spawn;

	static MexicanDogWaveController instance;

	void Start()
	{
		spawn = false;
	}

	void StartSpawn()
	{
		spawn = true;
		TimeSpawned = DateTime.Now;
		DogsSpawned = 0;
	}

	void Update()
	{
		if (spawn && DateTime.Now - TimeSpawned >= TimeSpan.FromSeconds(0.5))
		{
			if (DogsSpawned < DogCount)
			{
				Dog.Spawn (parent, spawnPos);
				TimeSpawned = DateTime.Now;
				DogsSpawned++;
			}
			else
			{
				spawn = false;
			}
		}
	}

	public override void Spawn(Transform parentTransform, Vector3 pos)
	{
		var v3Right = new Vector3(Screen.width,0,0);
		v3Right = Camera.main.ScreenToViewportPoint(v3Right);
		v3Right = new Vector3 (v3Right.x, .5f, Camera.main.transform.position.z);// + 8f + 6f);
		v3Right = Camera.main.ViewportToWorldPoint(v3Right);

		pos.x = -v3Right.x;

		if (instance == null)
		{
			instance = Instantiate (this);
		}

		instance.parent = parentTransform;
		instance.spawnPos = pos;

		instance.StartSpawn ();
	}
}
