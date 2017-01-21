using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacle : MonoBehaviour {

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
}
