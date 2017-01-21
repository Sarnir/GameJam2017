using System;
using UnityEngine;


[Serializable]
public class CommandRequirement
{
	public CommandType type;
	public int minFreq;
	public int maxFreq;
	public int framesCount;
	public KeyCode debugKey;
}

public enum CommandType
{
	LowRoar,
	SineWave,
	Screech,
	Hiss
}

public class AudioCommand
{
	public CommandRequirement requirement;
	FFT fft;

	public CommandType Type
	{
		get
		{
			return requirement.type;
		}
	}

	public AudioCommand(FFT _fft, CommandRequirement _requirement)
	{
		fft = _fft;
		requirement = _requirement;
	}

	public virtual void Execute()
	{
	}

	public virtual bool IsCalled ()
	{
		var freq = fft.GetAverageFrequency (requirement.framesCount);
		return freq < requirement.maxFreq && freq > requirement.minFreq;
	}
}
