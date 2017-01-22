using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroController : MonoBehaviour
{
	public int PanelsAmount;

	int Counter;
	public MovieTexture movTexture;

	void Start ()
	{
		movTexture.Play();
	}

	void OnGUI()
	{
		GUI.DrawTexture(new Rect(0,0,Screen.width,Screen.height),movTexture,ScaleMode.ScaleToFit);
	}
	
	void Update ()
	{
		if (movTexture.isPlaying == false || Input.GetKeyUp(KeyCode.Space))
		{
			SceneManager.LoadScene("Menu");
		}
	}
}
