using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DogController : MonoBehaviour
{
	Renderer Rend;

	// Use this for initialization
	void Start()
	{
		Rend = GetComponent<Renderer>();
	}

	// Update is called once per frame
	void Update()
	{

	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		throw new Exception(collision.gameObject.tag);
	}
}
