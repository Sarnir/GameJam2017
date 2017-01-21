using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour
{
	Transform Trans;

	void Start()
	{
		Trans = GetComponent<Transform>();
	}

	void Update()
	{
		Trans.position = new Vector2(Trans.position.x - 10, Trans.position.y);
		if (Trans.position.x < 0)
		{
			Destroy(gameObject);
		}
	}

	public virtual Obstacle Spawn(Transform parent, Vector3 pos)
	{
		var spawn = Instantiate<Obstacle>(this, parent, true);
		spawn.transform.position = pos;
		return spawn;
	}
}
