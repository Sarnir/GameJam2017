using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MicInput : MonoBehaviour {

	public AnimationCurve testCurve;
	AudioSource audioSource;

	void Start()
	{
		Debug.Log ("AudioSettings.outputSampleRate = " + AudioSettings.outputSampleRate);

		var devices = Microphone.devices;
		if(devices.Length > 0)
		{
			audioSource = GetComponent<AudioSource>();
			audioSource.clip = Microphone.Start(devices[0], true, 1, 4400);
			audioSource.loop = true;
			while (!(Microphone.GetPosition(null) > 0)){}
			audioSource.Play();
		}
	}

	void Update()
	{
		if (Microphone.IsRecording (Microphone.devices [0])) {
			Debug.Log ("Frequency: " + audioSource.clip.frequency);
			Debug.Log ("Pitch: " + audioSource.pitch);
		}

		float[] spectrum = new float[256];

		AudioListener.GetSpectrumData( spectrum, 0, FFTWindow.Hamming );

		for( int i = 1; i < spectrum.Length-1; i++ )
		{
			Debug.DrawLine( new Vector3( i - 1, spectrum[i] + 10, 0 ), new Vector3( i, spectrum[i + 1] + 10, 0 ), Color.red );
			Debug.DrawLine( new Vector3( i - 1, Mathf.Log( spectrum[i - 1] ) + 10, 2 ), new Vector3( i, Mathf.Log( spectrum[i] ) + 10, 2 ), Color.cyan );
			Debug.DrawLine( new Vector3( Mathf.Log( i - 1 ), spectrum[i - 1] - 10, 1 ), new Vector3( Mathf.Log( i ), spectrum[i] - 10, 1 ), Color.green );
			Debug.DrawLine( new Vector3( Mathf.Log( i - 1 ), Mathf.Log( spectrum[i - 1] ), 3 ), new Vector3( Mathf.Log( i ), Mathf.Log( spectrum[i] ), 3 ), Color.blue );
		}
	}

	/*WaveInEvent Wave;
	WaveFileWriter waveFile;

	// Use this for initialization
	void Start () {
		Wave = new NAudio.Wave.WaveInEvent();
		Wave.StartRecording ();
		Wave.DataAvailable += new System.EventHandler<WaveInEventArgs>(DataAvailable);

		var waveFormat = new WaveFormat ();

		//waveFile = new WaveFileWriter (Application.pa "Test0001.wav", waveFormat);
		//Microphone
		//Microphone.Start("", false, 
	}

	void DataAvailable(object sender, WaveInEventArgs args)
	{
		waveFile.Write (args.Buffer, 0, args.BytesRecorded);
		waveFile.Flush ();
	}

	public void StopRecording()
	{
		
	}

	// Update is called once per frame
	void Update () 
	{
	}*/
}
