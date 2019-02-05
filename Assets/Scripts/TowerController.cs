using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TowerController : MonoBehaviour
{
	[SerializeField] private GameObject Bullet;
	[SerializeField] protected int numbersOfBullet = 1;
	[SerializeField] protected float bulletSpeed = 50f;
	protected float fireRate = 1.0f;
	protected float nextFire = 0.0f;
	// Update is called once per frame

	public void FireEvent(string tag = "Enemy")
	{
		if ( Time.time >= nextFire)
		{
			nextFire = Time.time + fireRate;

			for (int i = 0; i < numbersOfBullet; i++)
			{
				Fire(tag);
			}

		}

	}
	protected void Fire(string tag)
	{
		int direction = GetComponentInParent<MovingController>().direction;

		Quaternion rotation = Quaternion.Euler(0, 0, getZRotation(direction));
		Vector2 position = transform.position;

		setBulletVelocity(direction);
		Bullet.GetComponent<BulletController>().creatorTag = tag;

		Instantiate(Bullet, position, rotation);
	}
	private void setBulletVelocity(int direction)
	{
		float bulletVelX = 0f;
		float bulletVelY = bulletSpeed;
		switch (direction)
		{
			case 3:
				{
					bulletVelX = bulletSpeed;
					bulletVelY = 0f;
					break;
				}
			case 4:
				{
					bulletVelX = bulletSpeed * (-1);
					bulletVelY = 0f;
					break;
				}
			case 2:
				{
					bulletVelX = 0f;
					bulletVelY = bulletSpeed * (-1);
					break;
				}
			default:
				{
					break;
				}
		}

		BulletController bulletController = Bullet.GetComponent<BulletController>();
		bulletController.velX = bulletVelX;
		bulletController.velY = bulletVelY;
	}

	private float getZRotation(int direction)
	{
		if (direction == 3)
		{
			return -90.0f;
		}
		else if (direction == 4)
		{
			return 90f;
		}

		if (direction == 1)
		{
			return 0f;
		}
		else if (direction == 2)
		{
			return 180f;
		}

		return 0f;
	}
}
