using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollController : MonoBehaviour
{
	public float SpeedModifier;
	Vector3 Obj1startPos;
	//Vector3 Obj2startPos;
	public Transform obj1;
	public Transform obj2;
	float width;

	Transform leftObj;
	Transform rightObj;

	// Use this for initialization
	void Start()
	{
		Obj1startPos = obj1.position;
		//Obj2startPos = obj2.position;
		width = obj2.position.x - obj1.position.x;
		leftObj = obj1;
		rightObj = obj2;
	}

	// Update is called once per frame
	void Update()
	{
		if (rightObj.position.x <= Obj1startPos.x)
		{
			leftObj.position = new Vector3 (leftObj.position.x + width, leftObj.position.y, leftObj.position.z);

			var tempPos = rightObj.position;
			rightObj.position = leftObj.position;
			leftObj.position = tempPos;
		}

		leftObj.position = new Vector3(leftObj.position.x - (SpeedModifier / 40), leftObj.position.y, leftObj.position.z);
		rightObj.position = new Vector3(rightObj.position.x - (SpeedModifier / 40), rightObj.position.y, rightObj.position.z);

		/*if (transform.position.x > StartPosition.x - width)
		{
			transform.position = new Vector3(transform.position.x - (SpeedModifier / 40), transform.position.y, transform.position.z);
		}
		else
		{
			transform.position = StartPosition;
		}*/
	}
}
