using UnityEngine;

public class Obstacle : MonoBehaviour
{
	public CommandType KilledByWaveType;

	Transform Trans;
	float DisappearPosition;

	public bool Paused;
	public float ObstacleSpeed;

	void Start()
	{
		Trans = GetComponent<Transform>();
		DisappearPosition = -Trans.position.x;
	}

	void Update()
	{
		if (Paused)
			return;
		Trans.position = new Vector3(Trans.position.x - ObstacleSpeed, Trans.position.y, Trans.position.z);
		if (Trans.position.x < DisappearPosition)
		{
			Destroy(gameObject);
		}
	}

	public virtual void Spawn(Transform parent, Vector3 pos)
	{
		if (Paused)
			return;
		
		var v3Right = new Vector3(Screen.width,0,0);
		v3Right = Camera.main.ScreenToViewportPoint(v3Right);
		v3Right = new Vector3 (v3Right.x, .5f, Camera.main.transform.position.z);// + 8f + 6f);
		v3Right = Camera.main.ViewportToWorldPoint(v3Right);

		var spawn = Instantiate<Obstacle>(this, parent, true);
		pos.x = -v3Right.x;
		spawn.transform.position = pos;
	}

	protected virtual void OnTriggerStay2D(Collider2D collider)
	{
		if (collider.gameObject.tag == "Wave")
		{
			var wave = collider.gameObject.GetComponent<WaveController>();
			if (wave.WaveType == KilledByWaveType)
				Destroy(gameObject);
		}
	}
}
