using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour
{
	public int PanelsAmount;

	int Counter;

	void Start ()
	{
		Counter = 1;
	}
	
	void Update ()
	{
		if (Input.GetKeyUp(KeyCode.Space))
		{
			if (Counter < PanelsAmount)
			{
				// change history comic panel
				Counter++;
			}
			else
			{
				SceneManager.LoadScene("Menu");
			}

		}
	}
}
