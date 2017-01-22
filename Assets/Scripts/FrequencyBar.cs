using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FrequencyBar : MonoBehaviour
{
	public Transform needle;
	public Transform freqMin;
	public Transform freqMax;

	CommandRequirement commandReq;
	float pitchCenter;

	// Use this for initialization
	void Awake ()
	{
		//SetCommand (CommandType.SineWave);
	}

	public void SetCommand(CommandType type)
	{
		commandReq = InputController.GetCommandReqs (type);
		pitchCenter = (commandReq.minFreq + commandReq.maxFreq) * 0.5f;
		//freqMin.localPosition = new Vector3 (GetNormalizedXPos (commandReq.minFreq), freqMin.localPosition.y, freqMin.localPosition.z);
		//freqMax.localPosition = new Vector3 (GetNormalizedXPos (commandReq.maxFreq), freqMax.localPosition.y, freqMax.localPosition.z);

		freqMin.localPosition = new Vector3 (XPosLog (commandReq.minFreq, pitchCenter), freqMin.localPosition.y, freqMin.localPosition.z);
		freqMax.localPosition = new Vector3 (XPosLog (commandReq.maxFreq, pitchCenter), freqMax.localPosition.y, freqMax.localPosition.z);
	}

	// Update is called once per frame
	void Update () 
	{
		//needle.localPosition =  new Vector3(GetNeedleXPos (), needle.localPosition.y, needle.localPosition.z);
		needle.localPosition =  new Vector3(XPosLog (FFT.CurrentPitch, pitchCenter), needle.localPosition.y, needle.localPosition.z);
	}

	float GetNeedleXPos()
	{
		return GetNormalizedXPos (FFT.CurrentPitch);
	}

	float GetNormalizedXPos(float freq)
	{
		var normalizedX = freq / (pitchCenter * 2f);
		normalizedX = (normalizedX * 20f) - 10f;
		Debug.Log ("normalizedX = " + normalizedX);

		var y = Mathf.Atan (normalizedX); // now y is between -pi/2 and pi/2

		y = y + Mathf.PI * 0.5f; // now y is between 0 and pi

		y = y / Mathf.PI; // now y is between 0 and 1
		y = (y * 2f) - 1; // -1 to 1


		y = Mathf.Clamp (y, -1f, 1f); // clamped just to be safe
		Debug.Log ("Y = " + y);
		//atan
		// wynik/90
		return y;
	}

	float XPosLog(float x, float center)
	{
		float a = 2f;

		var y = Mathf.Log (Mathf.Sqrt(x/center)+1f, a)/a; // from 0 to 1

		// if x = 1, y = 0.5, if x = 9, y = 1
		y = Mathf.Clamp01(y);

		return y*2f - 1f;
	}
}
