using UnityEngine;
using UnityEngine.SceneManagement;

public class CatController : MonoBehaviour
{
	public WaveController WavePrefab;

	public Animation GlassHit;
	public Animation WallHit;
	public Animation CucumberDeath;

	public Animator CatAnimator;

	bool cucumberWasDefeated;
	bool showCucumberTutorial;

	void Start()
	{
		cucumberWasDefeated = true;
		showCucumberTutorial = false;
	}

	void Update()
	{
		if (InputController.IsConditionMet(CommandType.LowRoar))
		{
			ShowWave(CommandType.LowRoar);
		}
		else if (InputController.IsConditionMet(CommandType.Screech))
		{
			ShowWave(CommandType.Screech);
		}
		else if (InputController.IsConditionMet(CommandType.Hiss))
		{
			if (showCucumberTutorial)
			{
				showCucumberTutorial = false;
				cucumberWasDefeated = true;
				LevelController.ForcePause = true;
			}

			ShowWave(CommandType.Hiss);
		}
		else if (InputController.IsConditionMet(CommandType.SineWave))
		{
			ShowWave(CommandType.SineWave);
		}
		else
		{
			WavePrefab.gameObject.SetActive(false);
		}
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Glass")
		{
			Die();
			collision.gameObject.AddComponent<Animation>();
		}
		else if (collision.gameObject.tag == "Wall")
		{
			Die();
			collision.gameObject.AddComponent<Animation>();
		}
		else if (collision.gameObject.tag == "Cucumber")
		{
			if (cucumberWasDefeated)
				Die ();
			else
			{
				showCucumberTutorial = true;
				LevelController.ForcePause = true;
			}
			collision.gameObject.AddComponent<Animation>();
		}
		else if (collision.gameObject.tag == "Dog")
		{
			Die();
			collision.gameObject.AddComponent<Animation>();
		}
	}

	void OnGUI()
	{
		if (showCucumberTutorial)
		{
			var guistyle = new GUIStyle ();
			guistyle.fontSize = 60;
			guistyle.alignment = TextAnchor.MiddleCenter;
			GUI.Label (new Rect (0, 0, Screen.width, Screen.height / 5f), "HISS LIKE A CAT!", guistyle);
		}
	}

	void Die()
	{
		SceneManager.LoadScene("GameOver");
	}

	void ShowWave(CommandType type)
	{
		WavePrefab.WaveType = type;
		WavePrefab.gameObject.SetActive(true);
	}
}
