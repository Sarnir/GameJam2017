using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveController : MonoBehaviour
{
	public CommandType WaveType
	{
		get
		{
			return waveType;
		}
		set
		{
			waveType = value;
			switch (waveType)
			{
				case CommandType.LowRoar:
					sr.color = Color.red;
					break;
				case CommandType.Screech:
					sr.color = Color.cyan;
					break;
				case CommandType.Hiss:
					sr.color = Color.yellow;
					break;
				default:
					sr.color = Color.white;
					break;
			}
		}
	}

	CommandType waveType;

	SpriteRenderer sr;

	// Use this for initialization
	void Start()
	{
		sr = GetComponent<SpriteRenderer>();
	}

	// Update is called once per frame
	void Update()
	{

	}
}
