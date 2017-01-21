using UnityEngine;

public class ScrollController : MonoBehaviour
{
	Transform Trans;
	public float SpeedModifier;
	Vector2 StartPosition;
	
	void Start()
	{
		Trans = GetComponent<Transform>();
		StartPosition = Trans.position;
	}
	
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
