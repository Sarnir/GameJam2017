using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollController : MonoBehaviour
{
	Transform Trans;
	public float SpeedModifier;
	Vector2 StartPosition;

	// Use this for initialization
	void Start()
	{
		Trans = GetComponent<Transform>();
		StartPosition = Trans.position;
	}

	// Update is called once per frame
	void Update()
	{
		if (Trans.position.x > -StartPosition.x)
		{
			Trans.position = new Vector2(Trans.position.x - (SpeedModifier / 40), Trans.position.y);
		}
		else
		{
			Trans.position = StartPosition;
		}
	}
}
