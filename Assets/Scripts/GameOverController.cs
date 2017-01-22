using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverController : MonoBehaviour
{
	void Update()
	{
		if (Input.GetKeyUp(KeyCode.Space) || Input.GetKeyUp(KeyCode.Escape))
		{
			SceneManager.LoadScene("Menu");
		}
	}
}
