using UnityEngine;

public class Obstacle : MonoBehaviour
{
	public CommandType KilledByWaveType;

	Transform Trans;
	float DisappearPosition;

	public bool Paused;

	void Start()
	{
		Trans = GetComponent<Transform>();
		DisappearPosition = -Trans.position.x;
	}

	void Update()
	{
		if (Paused)
			return;
		Trans.position = new Vector2(Trans.position.x - 0.125f, Trans.position.y);
		if (Trans.position.x < DisappearPosition)
		{
			Destroy(gameObject);
		}
	}

	public virtual void Spawn(Transform parent, Vector3 pos)
	{
		if (Paused)
			return;
		var spawn = Instantiate<Obstacle>(this, parent, true);
		spawn.transform.position = pos;
	}

	protected virtual void OnTriggerEnter2D(Collider2D collider)
	{
		Debug.Log(name + " collided with " + collider.gameObject.tag);
		if (collider.gameObject.tag == "Wave")
		{
			var wave = collider.gameObject.GetComponent<WaveController>();
			if (wave.WaveType == KilledByWaveType)
				Destroy(gameObject);
		}
	}
}
