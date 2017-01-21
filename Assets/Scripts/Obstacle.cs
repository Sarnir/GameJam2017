using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
	public CommandType KilledByWaveType;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public virtual Obstacle Spawn(Transform parent, Vector3 pos)
	{
		var spawn = Instantiate<Obstacle> (this, parent, true);
		spawn.transform.position = pos;
		return spawn;
	}

	protected void OnCollisionEnter2D(Collision2D collision)
	{
		Debug.Log ("collision.collider.gameObject.tag = " + collision.collider.gameObject.tag);
		if (collision.collider.gameObject.tag == "Wave")
		{
			var wave = collision.gameObject.GetComponent<WaveController> ();
			if (wave.waveType == KilledByWaveType)
				Destroy (gameObject);
		}
	}
}
