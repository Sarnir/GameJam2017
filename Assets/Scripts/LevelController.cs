using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
	public Obstacle DogPrefab;
	public Obstacle WallPrefab;
	public Obstacle GlassPrefab;
	public Obstacle CucumberPrefab;

	public Transform SpawnPos;

	public ScrollController SkyController;
	public ScrollController HillsController;
	public ScrollController GroundController;

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
		if (!Paused)
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
		}

		if (Input.GetKeyUp(KeyCode.Escape))
		{
			SceneManager.LoadScene("Menu");
		}

		if (Input.GetKeyUp(KeyCode.P))
		{
			if (!Paused)
			{
				Obstacle[] obstacles = GetComponentsInChildren<Obstacle>();
				foreach (Obstacle o in obstacles)
				{
					o.Paused = true;
				}
				Time.timeScale = 0;
				SkyController.SpeedModifier = 0;
				HillsController.SpeedModifier = 0;
				GroundController.SpeedModifier = 0;
				Paused = true;
			}
			else
			{
				Obstacle[] obstacles = GetComponentsInChildren<Obstacle>();
				foreach (Obstacle o in obstacles)
				{
					o.Paused = false;
				}
				Time.timeScale = 1;
				SkyController.SpeedModifier = 1;
				HillsController.SpeedModifier = 2;
				GroundController.SpeedModifier = 5;
				Paused = false;
			}
		}
	}
}
