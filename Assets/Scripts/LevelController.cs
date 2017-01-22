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

	public int SecondsBetweenSpawn;
	public int CurrentLevel;

	DateTime LevelStart;
	DateTime LastSpawned;
	bool Paused;
	public static bool ForcePause;

	void Start()
	{
		LevelStart = DateTime.Now;
		LastSpawned = DateTime.Now;
		Paused = false;
		ForcePause = false;
	}

	void Update()
	{
		HandleLevelChange();
		HandleSpawn();
		HandleExit();
		HandlePause();
	}

	private void HandleSpawn()
	{
		if (!Paused)
		{
			if (DateTime.Now - LastSpawned >= TimeSpan.FromSeconds(SecondsBetweenSpawn))
			{
				if (true) //UnityEngine.Random.value > 0.3f) // chance to spawn
				{
					float random = UnityEngine.Random.Range(0.0f, (float)CurrentLevel);
					if (random <= 1.0f)
					{
						CucumberPrefab.Spawn (transform, SpawnPos.position);
					}
					else if (random <= 2.0f)
						GlassPrefab.Spawn(transform, SpawnPos.position);
					else if (random <= 3.0f)
						DogPrefab.Spawn(transform, SpawnPos.position);
					else
						WallPrefab.Spawn(transform, SpawnPos.position);

					LastSpawned = DateTime.Now;
				}
			}
		}
	}

	private static void HandleExit()
	{
		if (Input.GetKeyUp(KeyCode.Escape))
		{
			SceneManager.LoadScene("Menu");
		}
	}

	void TogglePause()
	{
		if (!Paused)
		{
			Obstacle[] obstacles = GetComponentsInChildren<Obstacle>();
			foreach (Obstacle o in obstacles)
			{
				o.Paused = true;
			}
			//Time.timeScale = 0;
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

	private void HandlePause()
	{
		if (ForcePause || Input.GetKeyUp(KeyCode.P))
		{
			ForcePause = false;
			TogglePause ();
		}
	}

	private void HandleLevelChange()
	{
		if (!Paused && DateTime.Now - LevelStart > TimeSpan.FromSeconds( CurrentLevel * 6))
		{
			CurrentLevel++;
			if (CurrentLevel == 2)
			{
				Debug.Log("spawni pirszego szybę");
				SpawnFirstOfType(GlassPrefab);
				// load synthwave 1
			}
			else if (CurrentLevel == 3)
			{
				Debug.Log("spawni pirszego psa");
				SpawnFirstOfType(DogPrefab);
				// load normal 2
			}
			else
			{
				Debug.Log("spawni pirszego ściana");
				SpawnFirstOfType(WallPrefab);
				// load synthwave 2
			}
			LevelStart = DateTime.Now;
		}
	}

	private void SpawnFirstOfType(Obstacle obstacle)
	{
		obstacle.Spawn(transform, SpawnPos.position);
		LastSpawned = DateTime.Now;
	}
}
