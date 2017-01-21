using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundScrollController : MonoBehaviour
{
	Transform GroundTransform;
	SpriteRenderer GroundRenderer;

	// Use this for initialization
	void Start()
	{
		GroundTransform = GetComponent<Transform>();
	}

	// Update is called once per frame
	void Update()
	{
		GroundTransform.position.Set(GroundTransform.position.x - 2, GroundTransform.position.y, GroundTransform.position.z);
	}

	void OnBecameInvisible()
	{
		//calculate current position
		Vector3 position = GroundTransform.position;
		//calculate new position
		float x = position.x + Screen.width * 2;
		float y = position.y + Screen.height * 2;
		//move to new position when invisible
		gameObject.transform.position = new Vector3(x, y, 0f);
	}
}
