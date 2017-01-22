using System.Collections.Generic;
using UnityEngine;

public class CatController : MonoBehaviour
{
	public WaveController WavePrefab;

	public Animation GlassHit;
	public Animation WallHit;
	public Animation CucumberDeath;

	public Animator CatAnimator;

	private List<string> tags = new List<string> { "Glass", "Wall", "Cucumber", "Dog" };

	void Update()
	{
		if (InputController.IsConditionMet(CommandType.LowRoar))
		{
			ShowWave(CommandType.LowRoar);
		}
		else if (InputController.IsConditionMet(CommandType.SineWave))
		{
			ShowWave(CommandType.SineWave);
		}
		else if (InputController.IsConditionMet(CommandType.Screech))
		{
			ShowWave(CommandType.Screech);
		}
		else if (InputController.IsConditionMet(CommandType.Hiss))
		{
			ShowWave(CommandType.Hiss);
		}
		else
		{
			WavePrefab.gameObject.SetActive(false);
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (tags.Contains(collision.gameObject.tag))
		{
			// let CatAnimator play appropriate animation
		}
	}

	void ShowWave(CommandType type)
	{
		WavePrefab.WaveType = type;
		WavePrefab.gameObject.SetActive(true);
	}
}
