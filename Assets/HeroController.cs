using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroController : MonoBehaviour {

	FFT audioInput;

	// Use this for initialization
	void Start () {
		Application.runInBackground = true;
		audioInput = GetComponent<FFT> ();
	}
	
	// Update is called once per frame
	void Update () {
		audioInput.GetAverageFrequency (10);
	}
}
