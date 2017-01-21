using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
	public Obstacle DogPrefab;
	public Obstacle WallPrefab;
	public Obstacle GlassPrefab;
	public Obstacle CucumberPrefab;

	public Transform SpawnPos;

	public GameObject SkyObject;
	public GameObject HillsObject;
	public GameObject GroundObject;

	DateTime LastSpawned;
	bool Paused;

	// Use this for initialization
	void Start()
	{
		LastSpawned = DateTime.Now;
		Paused = false;
	}

	// Update is called once per frame
	void Update()
	{
		if (DateTime.Now - LastSpawned >= TimeSpan.FromSeconds(1))
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
					CucumberPrefab.Spawn(transform, SpawnPos.position);

				LastSpawned = DateTime.Now;
			}
		}

		if (Input.GetKey(KeyCode.Escape))
		{
			SceneManager.LoadScene("Menu");
		}
		if (Input.GetKey(KeyCode.P))
		{
			if (!Paused)
			{
				Time.timeScale = 0;
				//SkyObject.
				Paused = true;
			}
			else
			{
				Time.timeScale = 1;
				Paused = false;
			}
		}
	}
}
