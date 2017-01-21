using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
	public Obstacle DogPrefab;
	public Obstacle WallPrefab;
	public Obstacle GlassPrefab;

	public Transform SpawnPos;

	// Use this for initialization
	void Start()
	{
	}

	// Update is called once per frame
	void Update()
	{
		if (Random.value < 0.05f)
		{
			if (Random.value < 1f / 3f)
				DogPrefab.Spawn (transform, SpawnPos.position);
			else if (Random.value < 2f / 3f)
				WallPrefab.Spawn (transform, SpawnPos.position);
			else
				GlassPrefab.Spawn (transform, SpawnPos.position);
		}
			
	}
}
