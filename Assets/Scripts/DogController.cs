using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : Obstacle
{
	Renderer Rend;
	Rigidbody2D Rigid;

	// Use this for initialization
	void Start()
	{
		Rend = GetComponent<Renderer>();
		Rigid = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		Rigid.AddForce(Vector2.left * 5);
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		base.OnCollisionEnter2D (collision);
		if (collision.gameObject.tag == "Ground")
		{
			Rigid.AddForce(Vector2.up * 250);
		}
	}
}
