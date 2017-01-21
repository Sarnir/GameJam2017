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
					Anim.SetInteger("WaveType", 0);
					break;
				case CommandType.SineWave:
					sr.color = Color.cyan;
					Anim.SetInteger("WaveType", 1);
					break;
				case CommandType.Screech:
					sr.color = Color.yellow;
					Anim.SetInteger("WaveType", 2);
					break;
				case CommandType.Hiss:
					sr.color = Color.yellow;
					Anim.SetInteger("WaveType", 3);
					break;
				default:
					sr.color = Color.white;
					break;
			}
		}
	}

	CommandType waveType;
	Animator Anim;
	SpriteRenderer sr;

	// Use this for initialization
	void Start()
	{
		sr = GetComponent<SpriteRenderer>();
		Anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{

	}
}
