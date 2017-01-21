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
		if (InputController.IsConditionMet (CommandType.LowRoar))
			Debug.Log ("ROAR");
		else if (InputController.IsConditionMet (CommandType.Screech))
			Debug.Log ("SCREEEECH");
		else if (InputController.IsConditionMet (CommandType.Hiss))
			Debug.Log ("HISSSSSSSS");
	}
}
