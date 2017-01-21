using UnityEngine;

public class DogController : Obstacle
{
	Rigidbody2D Rigid;
	
	void Start()
	{
		Rigid = GetComponent<Rigidbody2D>();
	}
	
	void Update()
	{
		Rigid.AddForce(Vector2.left * 5);
	}

	protected void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.gameObject.tag == "Ground")
		{
			Rigid.AddForce(Vector2.up * 250);
		}
	}
}
