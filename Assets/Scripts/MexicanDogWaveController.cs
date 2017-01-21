using System;
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
				Dog.Spawn(parent, spawnPos);
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


		if (instance == null)
		{
			instance = Instantiate(this);
		}

		instance.parent = parentTransform;
		instance.spawnPos = pos;

		instance.StartSpawn();
	}
}
