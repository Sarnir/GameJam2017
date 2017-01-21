using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
	public Obstacle DogPrefab;
	public Obstacle WallPrefab;
	public Obstacle GlassPrefab;
	public Obstacle CucumberPrefab;

	public Transform SpawnPos;

	DateTime LastSpawned;

	// Use this for initialization
	void Start()
	{
		LastSpawned = DateTime.Now;
	}

	// Update is called once per frame
	void Update()
	{
		if (DateTime.Now - LastSpawned >= TimeSpan.FromSeconds(2))
		{
			float random = UnityEngine.Random.value;
			if (true) // może później szansa pojawienia się
			{
				if (random < 0.25f)
					DogPrefab.Spawn(transform, SpawnPos.position);
				else if (random < 0.5f)
					WallPrefab.Spawn(transform, SpawnPos.position);
				else if (random < 0.75f)
					GlassPrefab.Spawn(transform, SpawnPos.position);
				else
					GlassPrefab.Spawn(transform, SpawnPos.position);

				LastSpawned = DateTime.Now;
			}
		}
	}
}
