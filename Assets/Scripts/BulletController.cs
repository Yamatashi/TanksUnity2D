using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
	public float velX = 150f;
	public float velY = 0f;
	public int bulletDemage = 25;
	Rigidbody2D rgbd;
	public string creatorTag = "Player";
	// Start is called before the first frame update
	void Start()
	{
		rgbd = GetComponent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update()
	{
		rgbd.velocity = new Vector2(velX, velY);
	}
	void OnCollisionEnter2D(Collision2D col)
	{

		if (col.gameObject.tag == "Enemy" || col.gameObject.tag == "Player")
		{
			if (col.gameObject.tag == creatorTag)
			{
				Physics2D.IgnoreCollision(col.gameObject.GetComponent<BoxCollider2D>(), GetComponent<CapsuleCollider2D>());
			}
			else
			{
				GameObject colObject = col.gameObject;
				colObject.GetComponent<MovingController>().life -= bulletDemage;
				Destroy(this.gameObject);
			}
		}
		else if (col.gameObject.tag == "Wall")
		{
			GameObject colObject = col.gameObject;
			colObject.GetComponent<WallController>().life -= bulletDemage;
			Destroy(this.gameObject);
		}
		else if (col.gameObject.tag == "Stone")
		{
			Destroy(this.gameObject);
		}
		else if(col.gameObject.tag == "Bullet")
		{
			Destroy(this.gameObject);
			Destroy(col.gameObject);
		}


	}

}
