using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FFT : MonoBehaviour {

	int qSamples = 1024;  // array size
	float refValue = 0.1f; // RMS value for 0 dB
	float threshold = 0.02f;      // minimum amplitude to extract pitch
	float rmsValue;   // sound level - RMS
	float dbValue;    // sound level - dB
	float pitchValue; // sound pitch - Hz

	float[] samples; // audio samples
	float[] spectrum; // audio spectrum
	float fSample;

	AudioSource audioSource;
	float[] debugSamples;

	// Use this for initialization
	void Start ()
	{
		debugSamples = new float[128];
		samples = new float[qSamples];
		spectrum = new float[qSamples];
		fSample = AudioSettings.outputSampleRate;

		var devices = Microphone.devices;
		if(devices.Length > 0)
		{
			audioSource = GetComponent<AudioSource>();
			audioSource.clip = Microphone.Start(devices[0], true, 1, (int)fSample);
			audioSource.loop = true;
			while (!(Microphone.GetPosition(null) > 0)){}
			audioSource.Play();
		}
	}

	// Update is called once per frame
	void Update ()
	{
		AnalyzeSound();
		/*Debug.Log("RMS: "+rmsValue.ToString("F2")+
				" ("+dbValue.ToString("F1")+" dB)\n"+
				"Pitch: "+pitchValue.ToString("F0")+" Hz");*/

		DrawDebugGraph ();
	}

	void AnalyzeSound()
	{
		audioSource.GetOutputData(samples, 0); // fill array with samples
		int i;
		float sum = 0f;
		for (i=0; i < qSamples; i++){
			sum += samples[i]*samples[i]; // sum squared samples
		}
		rmsValue = Mathf.Sqrt(sum/qSamples); // rms = square root of average
		dbValue = 20*Mathf.Log10(rmsValue/refValue); // calculate dB
		if (dbValue < -160) dbValue = -160; // clamp it to -160dB min

		// get sound spectrum
		audioSource.GetSpectrumData(spectrum, 0, FFTWindow.BlackmanHarris);
		float maxV = 0f;
		int maxN = 0;

		// find max 
		for (i=0; i < qSamples; i++)
		{ 
			if (spectrum[i] > maxV && spectrum[i] > threshold){
				maxV = spectrum[i];
				maxN = i; // maxN is the index of max
			}
		}
		float freqN = maxN; // pass the index to a float variable

		// interpolate index using neighbours
		if (maxN > 0 && maxN < qSamples-1)
		{
			var dL = spectrum[maxN-1]/spectrum[maxN];
			var dR = spectrum[maxN+1]/spectrum[maxN];
			freqN += 0.5f*(dR*dR - dL*dL);
		}
		pitchValue = freqN*(fSample/2)/qSamples; // convert index to frequency
	}

	void DrawDebugGraph()
	{
			for (int i = 1; i < debugSamples.Length; i++)
			{
				debugSamples [i - 1] = debugSamples[i];
			}

			debugSamples [debugSamples.Length - 1] = pitchValue;

		for( int i = 1; i < debugSamples.Length-1; i++ )
		{
			Debug.DrawLine( new Vector3( i - 1, debugSamples[i - 1]*0.1f, 0 ), new Vector3( i, debugSamples[i]*0.1f, 0 ), Color.red );
		}
	}

	void OnGUI()
	{
		if (Application.isEditor)  // or check the app debug flag
		{
			GUI.Label(new Rect(30, 30, 300, 300), "Freq = " + pitchValue);
		}
	}

	public float GetAverageFrequency(int samplesCount)
	{
		float average = 0;
		int i = debugSamples.Length - samplesCount;
		if (i < 0)
			i = 0;
		
		for (; i < debugSamples.Length; i++)
		{
			if (debugSamples [i] > 0)
				average += debugSamples [i];
			else
				return 0; // signal must be constantly above 0 during sampling
		}

		average /= samplesCount;

		//Debug.Log ("Avg freq = " + average);
		
		return average;
	}

	public static float FrequencyToMidiCode( float frequency, float tuningA = 440f )
	{
		return 69 + ( 12 * ( Mathf.Log( frequency / tuningA, 2f ) ) );
	}
}
