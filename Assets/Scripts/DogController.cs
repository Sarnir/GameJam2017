using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : Obstacle
{
	Rigidbody2D Rigid;

	// Use this for initialization
	void Start()
	{
		Rigid = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		Rigid.AddForce(Vector2.left * 5);
	}

	protected override void OnCollisionEnter2D(Collision2D collision)
	{
		base.OnCollisionEnter2D (collision);
		if (collision.gameObject.tag == "Ground")
		{
			Rigid.AddForce(Vector2.up * 250);
		}
	}
}
