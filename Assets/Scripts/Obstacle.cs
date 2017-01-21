using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
	public CommandType KilledByWaveType;
	Transform Trans;
	float DisappearPosition;

	void Start()
	{
		Trans = GetComponent<Transform>();
		DisappearPosition = -Trans.position.x;
	}

	void Update()
	{
		Trans.position = new Vector2(Trans.position.x - 0.125f, Trans.position.y);
		if (Trans.position.x < DisappearPosition)
		{
			Destroy(gameObject);
		}
	}

	public virtual void Spawn(Transform parent, Vector3 pos)
	{
		var spawn = Instantiate<Obstacle>(this, parent, true);
		spawn.transform.position = pos;
	}

	protected virtual void OnCollisionEnter2D(Collision2D collision)
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
