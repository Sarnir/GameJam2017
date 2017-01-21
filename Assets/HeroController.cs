using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour {

	public CommandRequirement[] commandsReqs;

	FFT audioInput;
	AudioCommand command;

	void Start ()
	{
		Application.runInBackground = true;
	}

	void Update ()
	{
		
	}
}
