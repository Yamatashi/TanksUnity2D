using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingController : MonoBehaviour
{

	[SerializeField] private Rigidbody2D RigidBody;
	[SerializeField] private BoxCollider2D BoxCollider;
	[SerializeField] private LayerMask layerMask;

	public int life = 100;
	/*
	 * directions status
	 * 1 - top
	 * 2 - bottom
	 * 3 - left
	 * 4 - right
	 * 
	 */

	public int direction = 0;
	// Start is called before the first frame update
	void Start()
	{
		BoxCollider = GetComponent<BoxCollider2D>();
		RigidBody = GetComponent<Rigidbody2D>();
	}

	protected bool MoveObject(int x, int y, out RaycastHit2D hit)
	{
		Vector2 start = transform.position;
		Vector2 end = start + new Vector2(x, y);
		BoxCollider.enabled = false;
		hit = Physics2D.Linecast(start, end, layerMask);
		BoxCollider.enabled = true;
		if (hit.transform == null)
		{
			transform.eulerAngles = rotateObject(x, y);
			RigidBody.MovePosition(end);
			return true;
		}


		return false;
	}

	private Vector3 rotateObject(int x, int y)
	{
		Vector3 output = new Vector3(0, 0, 0);
		if (x > 0)
		{
			direction = 3;
			output = new Vector3(0, 0, -90);
		}
		else if (x < 0)
		{
			direction = 4;
			output = new Vector3(0, 0, 90);
		}

		if (y > 0)
		{
			direction = 1;
			output = new Vector3(0, 0, 0);
		}
		else if (y < 0)
		{
			direction = 2;
			output = new Vector3(0, 0, 180);
		}

		return output;
	}
}
