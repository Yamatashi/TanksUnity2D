using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MovingController
{
	public int horizontal = 0;
	public int vertical = 0;
	public string enemyDirection;
	protected float moveRate = 3.0f;
	protected float nextMove = 0.0f;
	protected float fireRate = 3.0f;
	protected float nextFire = 0.0f;

	
	// Update is called once per frame
	void Update()
	{
		if(Time.time >= nextMove )
		{
			nextMove = Time.time + moveRate;
			enemyDirection = RandMoveDirection();
		}

		if(Time.time >= nextFire)
		{
			nextFire = Time.time + randomFireRate();
			TowerController tower = GetComponentInChildren<TowerController>();
			tower.FireEvent();
		}
		
		if(enemyDirection == "forward")
		{
			horizontal = 1;
			vertical = 0;
		} else if(enemyDirection == "down")
		{
			horizontal = -1;
			vertical = 0;
		} else if(enemyDirection == "left")
		{
			horizontal = 0;
			vertical = -1;
		} else
		{
			horizontal = 0;
			vertical = 1;
		}

		if (horizontal != 0 || vertical != 0)
		{
			RaycastHit2D hit;
			if(!MoveObject(horizontal, vertical, out hit))
			{
				nextMove = Time.time;
			}
			
		}

		if (life == 0)
		{
			Destroy(this.gameObject);
			SceneManager.LoadScene("Win");
		}
	}

	private float randomFireRate()
	{
		System.Random r = new System.Random();

		return r.Next(2, 5);
	}

	private string RandMoveDirection()
	{
		System.Random r = new System.Random();

		int random = r.Next(0, 100);

		if(random >= 0 && random < 25)
		{
			return "forward";
		} else if(random >= 25 && random < 50)
		{
			return "left";
		} else if(random >= 50 && random < 75)
		{
			return "right";
		} else
		{
			return "down";
		}
	}
}
